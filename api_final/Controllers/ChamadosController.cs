using Microsoft.AspNetCore.Mvc;
using api_final.DTOs;
using api_final.Services;

namespace api_final.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChamadoController : ControllerBase
    {
        private readonly ChamadoService _chamadoService;

        public ChamadoController(ChamadoService chamadoService)
        {
            _chamadoService = chamadoService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ChamadoDTO>> GetTodos()
        {
            var chamados = _chamadoService.GetTodos();
            return Ok(chamados);
        }

        [HttpGet("{id}")]
        public ActionResult<ChamadoDTO> GetPorId(int id)
        {
            var chamado = _chamadoService.GetPorId(id);
            if (chamado == null)
                return NotFound();

            return Ok(chamado);
        }

        [HttpPost]
        public ActionResult<ChamadoDTO> CriarChamado([FromBody] ChamadoDTO dto)
        {
            var novoChamado = _chamadoService.CriarChamado(dto);
            return CreatedAtAction(nameof(GetPorId), new { id = novoChamado.Id }, novoChamado);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarChamado(int id, [FromBody] ChamadoDTO dto)
        {
            var atualizado = _chamadoService.AtualizarChamado(id, dto);
            if (!atualizado)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarChamado(int id)
        {
            var deletado = _chamadoService.DeletarChamado(id);
            if (!deletado)
                return NotFound();

            return NoContent();
        }
    }
}
