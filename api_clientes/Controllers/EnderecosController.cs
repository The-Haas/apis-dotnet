using System.Collections.Generic;
using api_clientes.Services;
using api_clientes.Services.DTOs;
using api_clientes.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace api_clientes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecosController : ControllerBase
    {
        private readonly EnderecosService _service;

        public EnderecosController(EnderecosService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult<EnderecoDTO> Criar([FromBody] CriarEnderecoDTO dto)
        {
            try
            {
                return Ok(_service.Criar(dto));
            }
            catch (BadRequestException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<EnderecoDTO> Buscar(int id)
        {
            try
            {
                return Ok(_service.BuscarPorId(id));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<EnderecoDTO>> ListarTodos()
        {
            return Ok(_service.ListarTodos());
        }

        [HttpDelete("{id}")]
        public ActionResult Deletar(int id)
        {
            try
            {
                _service.Deletar(id);
                return NoContent();
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<EnderecoDTO> Atualizar(int id, [FromBody] AtualizarEnderecoDTO dto)
        {
            try
            {
                return Ok(_service.Atualizar(id, dto));
            }
            catch (BadRequestException e)
            {
                return BadRequest(e.Message);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPatch("{id}")]
        public ActionResult<EnderecoDTO> Patch(int id, [FromBody] PatchEnderecoDTO dto)
        {
            try
            {
                return Ok(_service.Patch(id, dto));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }





    }
}
