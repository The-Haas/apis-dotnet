using Microsoft.AspNetCore.Mvc;
using api_final.Services;
using api_final.Services.DTOs;
using FluentValidation;

namespace api_final.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json", "application/xml")]
    public class TelefonesController : ControllerBase
    {
        private readonly TelefonesService _service;
        private readonly IValidator<TelefoneRequestDTO> _validator;

        public TelefonesController(TelefonesService service, IValidator<TelefoneRequestDTO> validator)
        {
            _service = service;
            _validator = validator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TelefoneResponseDTO>>> Get()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TelefoneResponseDTO>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<TelefoneResponseDTO>> Post([FromBody] TelefoneRequestDTO dto)
        {
            var validation = await _validator.ValidateAsync(dto);
            if (!validation.IsValid)
                return BadRequest(validation.Errors);

            var criado = await _service.CreateComValidacaoAsync(dto);

            if (criado == null)
                return NotFound(new { message = "Cliente não encontrado." });

            return CreatedAtAction(nameof(GetById), new { id = criado.IdTelefone }, criado);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TelefoneRequestDTO dto)
        {
            var validation = await _validator.ValidateAsync(dto);
            if (!validation.IsValid)
                return BadRequest(validation.Errors);

            var atualizado = await _service.UpdateAsync(id, dto);

            if (atualizado == null)
                return NotFound(new { message = "Telefone ou Cliente não encontrado." });

            return Ok(atualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
