
// Controller que recebe as requisições HTTP relacionadas a chamados, 
// valida os dados com FluentValidation e chama o serviçe para executar a lógica.
// É o ponto de entrada da API para operações CRUD de chamados, chamado pelo cliente (front-end ou outro serviço).
using Microsoft.AspNetCore.Mvc;
using api_final.DTOs;
using api_final.Services;
using FluentValidation;

namespace api_final.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json", "application/xml")]
    public class ChamadoController : ControllerBase
    {
        private readonly ChamadoService _service;
        private readonly IValidator<ChamadoRequestDTO> _validator;

        public ChamadoController(ChamadoService service, IValidator<ChamadoRequestDTO> validator)
        {
            _service = service;
            _validator = validator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChamadoResponseDTO>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ChamadoResponseDTO>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ChamadoResponseDTO>> Create(ChamadoRequestDTO dto)
        {
            var validation = await _validator.ValidateAsync(dto);
            if (!validation.IsValid)
                return BadRequest(validation.Errors);

            var result = await _service.CreateAsync(dto);
            return result == null ? NotFound("Cliente ou Responsável não encontrado.") : Created("", result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ChamadoRequestDTO dto)
        {
            var validation = await _validator.ValidateAsync(dto);
            if (!validation.IsValid)
                return BadRequest(validation.Errors);

            var success = await _service.UpdateAsync(id, dto);
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}
