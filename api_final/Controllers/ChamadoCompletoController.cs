using Microsoft.AspNetCore.Mvc;
using api_final.DTOs;
using api_final.Services;

namespace api_final.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json", "application/xml")]
    public class ChamadoCompletoController : ControllerBase
    {
        private readonly ChamadoCompletoService _service;

        public ChamadoCompletoController(ChamadoCompletoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChamadoCompletoResponseDTO>>> GetChamadosCompletos()
        {
            var result = await _service.GetChamadosCompletosAsync();
            return Ok(result);
        }

        [HttpGet("cliente/{idCliente}")]
        public async Task<ActionResult<IEnumerable<ChamadoCompletoResponseDTO>>> GetChamadosCompletosPorCliente(int idCliente)
        {
            var result = await _service.GetChamadosCompletosPorClienteAsync(idCliente);

            if (result == null || result.Count == 0)
                return NotFound($"Nenhum chamado encontrado para o cliente com ID {idCliente}.");

            return Ok(result);
        }

        [HttpGet("{idChamado}")]
        public async Task<ActionResult<ChamadoCompletoResponseDTO>> GetChamadoCompletoPorId(int idChamado)
        {
            var result = await _service.GetChamadoCompletoPorIdAsync(idChamado);

            if (result == null)
                return NotFound($"Chamado com ID {idChamado} não encontrado.");

            return Ok(result);
        }

        [HttpGet("responsavel/{idResponsavel}")]
        public async Task<ActionResult<IEnumerable<ChamadoCompletoResponseDTO>>> GetChamadosCompletosPorResponsavel(int idResponsavel)
        {
            var result = await _service.GetChamadosCompletosPorResponsavelAsync(idResponsavel);

            if (result == null || result.Count == 0)
                return NotFound($"Nenhum chamado encontrado para o responsável com ID {idResponsavel}.");

            return Ok(result);
        }



    }


}
