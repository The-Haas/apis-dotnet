
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
    [Route("api/[controller]")]                           // Rota base para esse controller
    [Produces("application/json", "application/xml")]     // Response em JSON e XML
    public class ChamadoController : ControllerBase       // Define a classe ChamadoController como um ControllerBase.
    {
        private readonly ChamadoService _service;                    // Acessar os métodos do service.
        private readonly IValidator<ChamadoRequestDTO> _validator;   // Validador do FluentValidation para o DTO de requisição.

        // Construtor da classe ChamadoController.
        public ChamadoController(ChamadoService service, IValidator<ChamadoRequestDTO> validator)
        {
            _service = service;
            _validator = validator;
        }


        // Metodo assincrono que retorna uma lista de objetos do tipo ChamadoResponseDTO
        // Task: o metodo é assincrono e pode ser aguardado (usando 'await')
        // ActionResult pra retornar códigos HTTP
        // IEnumerable é a resposta principal, é uma coleção de objetos DTO representando os chamados que pode ser percorrido
        // IActionResult permite que o método retorne diferentes statuscode http
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChamadoResponseDTO>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ChamadoResponseDTO>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            // Operador ternário, se for null, retorna Not Found, senão OK
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
