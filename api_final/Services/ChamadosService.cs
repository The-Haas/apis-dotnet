using AutoMapper;
using api_final.Database;
using api_final.Database.Models;
using api_final.DTOs;

namespace api_final.Services
{
    public class ChamadoService
    {
        private readonly ChamadosContext _context;
        private readonly IMapper _mapper;

        public ChamadoService(ChamadosContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ChamadoDTO> GetTodos()
        {
            var chamados = _context.Chamados.ToList();
            return _mapper.Map<List<ChamadoDTO>>(chamados);
        }

        public ChamadoDTO? GetPorId(int id)
        {
            var chamado = _context.Chamados.Find(id);
            return chamado == null ? null : _mapper.Map<ChamadoDTO>(chamado);
        }

        public ChamadoDTO CriarChamado(ChamadoDTO dto)
        {
            var chamado = _mapper.Map<Chamado>(dto);
            //chamado.DataCriacao = DateTime.Now;
            _context.Chamados.Add(chamado);
            _context.SaveChanges();
            return _mapper.Map<ChamadoDTO>(chamado);
        }

        public bool AtualizarChamado(int id, ChamadoDTO dto)
        {
            var chamado = _context.Chamados.Find(id);
            if (chamado == null)
                return false;

            _mapper.Map(dto, chamado); // Atualiza os campos da entidade
            _context.SaveChanges();
            return true;
        }

        public bool DeletarChamado(int id)
        {
            var chamado = _context.Chamados.Find(id);
            if (chamado == null)
                return false;

            _context.Chamados.Remove(chamado);
            _context.SaveChanges();
            return true;
        }
    }
}