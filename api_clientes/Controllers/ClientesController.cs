using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_clientes.Database.Models;
using api_clientes.Services;
using api_clientes.Services.DTOs;
using api_clientes.Services.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_clientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {

        private readonly ClientesService _service;


        public ClientesController(ClientesService service)
        {
            _service = service;
        }


        [HttpPost]
        public ActionResult<ClienteDTO> Adicionar([FromBody] CriarClienteDTO body)
        {

            try
            {
                var Response = _service.Criar(body);

                return Ok(Response); //200
            }
            catch (BadRequestException B)
            {
                return BadRequest(B.Message); //400
            }
            catch (System.Exception E)
            {
                return BadRequest(E.Message); //500
            }

            
        }

        [HttpGet]
        public ActionResult<List<ClienteDTO>> ListarTodos()
        {
            try
            {
                var lista = _service.ListarTodos();
                return Ok(lista); // 200
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // 500
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ClienteDTO> BuscarPorId(int id)
        {
            try
            {
                var cliente = _service.BuscarPorId(id);
                return Ok(cliente); // 200
            }
            catch (BadRequestException b)
            {
                return NotFound(b.Message); // 404
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // 500
            }
        }

        [HttpPut("{id}")]
        public ActionResult<ClienteDTO> Atualizar(int id, [FromBody] CriarClienteDTO body)
        {
            try
            {
                var clienteAtualizado = _service.Atualizar(id, body);
                return Ok(clienteAtualizado); // 200
            }
            catch (BadRequestException b)
            {
                return NotFound(b.Message); // 404
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // 500
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Remover(int id)
        {
            try
            {
                _service.Remover(id);
                return NoContent(); // 204: sucesso, sem conteúdo
            }
            catch (BadRequestException b)
            {
                return NotFound(b.Message); // 404
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // 500
            }
        }

        [HttpPatch("{id}")]
        public ActionResult<ClienteDTO> AtualizarParcial(int id, [FromBody] AtualizarClienteDTO body)
        {
            try
            {
                var clienteAtualizado = _service.AtualizarParcialmente(id, body);
                return Ok(clienteAtualizado); // 200
            }
            catch (BadRequestException b)
            {
                return NotFound(b.Message); // 404
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // 500
            }
        }



    }
}
