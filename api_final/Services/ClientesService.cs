using api_final.Database.Models;
using api_final.Services.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api_final.Services
{
    public class ClientesService
    {
        private readonly ChamadosContext _context;
        private readonly IMapper _mapper;

        public ClientesService(ChamadosContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ClienteResponseDTO>> GetAllAsync()
        {
            var clientes = await _context.Clientes.ToListAsync();
            return _mapper.Map<List<ClienteResponseDTO>>(clientes);
        }

        public async Task<ClienteResponseDTO?> GetByIdAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            return cliente == null ? null : _mapper.Map<ClienteResponseDTO>(cliente);
        }

        public async Task<ClienteResponseDTO> CreateAsync(ClienteRequestDTO dto)
        {
            var cliente = _mapper.Map<Cliente>(dto);
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return _mapper.Map<ClienteResponseDTO>(cliente);
        }

        public async Task<bool> UpdateAsync(int id, ClienteRequestDTO dto)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return false;

            _mapper.Map(dto, cliente);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return false;

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
