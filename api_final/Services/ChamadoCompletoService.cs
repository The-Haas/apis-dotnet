using AutoMapper;
using Microsoft.EntityFrameworkCore;
using api_final.Database.Models;
using api_final.DTOs;

namespace api_final.Services
{
    public class ChamadoCompletoService
    {
        private readonly ChamadosContext _context;
        private readonly IMapper _mapper;

        public ChamadoCompletoService(ChamadosContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ChamadoCompletoResponseDTO>> GetChamadosCompletosAsync()
        {
            var chamados = await _context.Chamados
                .Include(c => c.IdClienteNavigation)
                    .ThenInclude(cliente => cliente.Telefones)
                .Include(c => c.IdClienteNavigation)
                    .ThenInclude(cliente => cliente.Emails)
                .Include(c => c.IdResponsavelNavigation)
                .ToListAsync();

            return _mapper.Map<List<ChamadoCompletoResponseDTO>>(chamados);
        }

        public async Task<List<ChamadoCompletoResponseDTO>> GetChamadosCompletosPorClienteAsync(int idCliente)
        {
            var chamados = await _context.Chamados
                .Where(c => c.IdCliente == idCliente)
                .Include(c => c.IdClienteNavigation)
                    .ThenInclude(cliente => cliente.Telefones)
                .Include(c => c.IdClienteNavigation)
                    .ThenInclude(cliente => cliente.Emails)
                .Include(c => c.IdResponsavelNavigation)
                .ToListAsync();

            return _mapper.Map<List<ChamadoCompletoResponseDTO>>(chamados);
        }

        public async Task<ChamadoCompletoResponseDTO?> GetChamadoCompletoPorIdAsync(int idChamado)
        {
            var chamado = await _context.Chamados
                .Where(c => c.IdChamado == idChamado)
                .Include(c => c.IdClienteNavigation)
                    .ThenInclude(cliente => cliente.Telefones)
                .Include(c => c.IdClienteNavigation)
                    .ThenInclude(cliente => cliente.Emails)
                .Include(c => c.IdResponsavelNavigation)
                .FirstOrDefaultAsync();

            return chamado == null ? null : _mapper.Map<ChamadoCompletoResponseDTO>(chamado);
        }

        public async Task<List<ChamadoCompletoResponseDTO>> GetChamadosCompletosPorResponsavelAsync(int idResponsavel)
        {
            var chamados = await _context.Chamados
                .Where(c => c.IdResponsavel == idResponsavel)
                .Include(c => c.IdClienteNavigation)
                    .ThenInclude(cliente => cliente.Telefones)
                .Include(c => c.IdClienteNavigation)
                    .ThenInclude(cliente => cliente.Emails)
                .Include(c => c.IdResponsavelNavigation)
                .ToListAsync();

            return _mapper.Map<List<ChamadoCompletoResponseDTO>>(chamados);
        }


    }


}
