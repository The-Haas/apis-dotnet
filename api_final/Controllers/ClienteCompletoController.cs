using Microsoft.AspNetCore.Mvc;
using api_final.DTOs;
using api_final.Services;

namespace api_final.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json", "application/xml")]
    public class ClienteCompletoController : ControllerBase
    {
        private readonly ClienteCompletoService _service;

        public ClienteCompletoController(ClienteCompletoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteCompletoResponseDTO>>> GetClientesCompletos()
        {
            var result = await _service.GetClientesCompletosAsync();
            return Ok(result);
        }

        [HttpGet("{idCliente}")]
        public async Task<ActionResult<ClienteCompletoResponseDTO>> GetClienteCompletoPorId(int idCliente)
        {
            var result = await _service.GetClienteCompletoPorIdAsync(idCliente);

            if (result == null)
                return NotFound($"Cliente com ID {idCliente} não encontrado.");

            return Ok(result);
        }
    }
}
