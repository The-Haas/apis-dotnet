using AutoMapper;
using Microsoft.EntityFrameworkCore;
using api_final.Database.Models;
using api_final.DTOs;

namespace api_final.Services
{
    public class ClienteCompletoService
    {
        private readonly ChamadosContext _context;
        private readonly IMapper _mapper;

        public ClienteCompletoService(ChamadosContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ClienteCompletoResponseDTO>> GetClientesCompletosAsync()
        {
            var clientes = await _context.Clientes
                .Include(c => c.Telefones)
                .Include(c => c.Emails)
                .ToListAsync();

            return _mapper.Map<List<ClienteCompletoResponseDTO>>(clientes);
        }

        public async Task<ClienteCompletoResponseDTO?> GetClienteCompletoPorIdAsync(int idCliente)
        {
            var cliente = await _context.Clientes
                .Where(c => c.IdCliente == idCliente)
                .Include(c => c.Telefones)
                .Include(c => c.Emails)
                .FirstOrDefaultAsync();

            return cliente == null ? null : _mapper.Map<ClienteCompletoResponseDTO>(cliente);
        }
    }
}
