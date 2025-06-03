using Microsoft.AspNetCore.Mvc;
using api_final.DTOs;
using api_final.Services;
using FluentValidation;
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations;


namespace api_final.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json", "application/xml")]
    public class ResponsaveisController : ControllerBase
    {
        private readonly ResponsaveisService _service;
        private readonly IValidator<ResponsavelRequestDTO> _validator;

        public ResponsaveisController(ResponsaveisService service, IValidator<ResponsavelRequestDTO> validator)
        {
            _service = service;
            _validator = validator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponsavelResponseDTO>>> Get()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponsavelResponseDTO>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ResponsavelResponseDTO>> Post([FromBody] ResponsavelRequestDTO dto)
        {
            FluentValidation.Results.ValidationResult validation = await _validator.ValidateAsync(dto);

            if (!validation.IsValid)
                return BadRequest(validation.Errors);

            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.IdResponsavel }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ResponsavelRequestDTO dto)
        {
            FluentValidation.Results.ValidationResult validation = await _validator.ValidateAsync(dto);

            if (!validation.IsValid)
                return BadRequest(validation.Errors);

            var updated = await _service.UpdateAsync(id, dto);
            if (!updated) return NotFound();
            return NoContent();
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
