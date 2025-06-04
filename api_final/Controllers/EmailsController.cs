using Microsoft.AspNetCore.Mvc;
using api_final.Services;
using api_final.Services.DTOs;

namespace api_final.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json", "application/xml")]
    public class EmailsController : ControllerBase
    {
        private readonly EmailsService _service;

        public EmailsController(EmailsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmailResponseDTO>>> Get()
        {
            var emails = await _service.GetAllAsync();
            return Ok(emails);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmailResponseDTO>> GetById(int id)
        {
            var email = await _service.GetByIdAsync(id);
            if (email == null)
                return NotFound("Email não encontrado.");
            return Ok(email);
        }

        [HttpPost]
        public async Task<ActionResult<EmailResponseDTO>> Post([FromBody] EmailRequestDTO dto)
        {
            try
            {
                var criado = await _service.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = criado.IdEmail }, criado);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Cliente não encontrado.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmailResponseDTO>> Put(int id, [FromBody] EmailRequestDTO dto)
        {
            var atualizado = await _service.UpdateAsync(id, dto);
            if (atualizado == null)
                return NotFound("Email ou cliente não encontrado.");
            return Ok(atualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var removido = await _service.DeleteAsync(id);
            if (!removido)
                return NotFound("Email não encontrado.");
            return NoContent();
        }
    }
}
