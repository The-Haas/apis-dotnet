using AutoMapper;
using Microsoft.EntityFrameworkCore;
using api_final.Database.Models;
using api_final.Services.DTOs;

namespace api_final.Services
{
    public class TelefonesService
    {
        private readonly ChamadosContext _context;
        private readonly IMapper _mapper;

        public TelefonesService(ChamadosContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TelefoneResponseDTO?> CreateComValidacaoAsync(TelefoneRequestDTO dto)
        {
            var clienteExiste = await _context.Clientes
                .AnyAsync(c => c.IdCliente == dto.IdCliente);

            if (!clienteExiste)
                return null;

            var telefone = _mapper.Map<Telefone>(dto);
            _context.Telefones.Add(telefone);
            await _context.SaveChangesAsync();

            return _mapper.Map<TelefoneResponseDTO>(telefone);
        }

        public async Task<List<TelefoneResponseDTO>> GetAllAsync()
        {
            var telefones = await _context.Telefones.ToListAsync();
            return _mapper.Map<List<TelefoneResponseDTO>>(telefones);
        }

        public async Task<TelefoneResponseDTO?> GetByIdAsync(int id)
        {
            var telefone = await _context.Telefones.FindAsync(id);
            return telefone == null ? null : _mapper.Map<TelefoneResponseDTO>(telefone);
        }

        public async Task<TelefoneResponseDTO> CreateAsync(TelefoneRequestDTO dto)
        {
            var telefone = _mapper.Map<Telefone>(dto);
            _context.Telefones.Add(telefone);
            await _context.SaveChangesAsync();
            return _mapper.Map<TelefoneResponseDTO>(telefone);
        }

        public async Task<TelefoneResponseDTO?> UpdateAsync(int id, TelefoneRequestDTO dto)
        {
            var telefone = await _context.Telefones.FindAsync(id);

            if (telefone == null)
                return null; // Telefone não existe

            var clienteExiste = await _context.Clientes.AnyAsync(c => c.IdCliente == dto.IdCliente);

            if (!clienteExiste)
                return null; // Cliente não existe

            // Atualiza os dados do telefone
            telefone.NumeroTelefone = dto.NumeroTelefone;
            telefone.IdCliente = dto.IdCliente;

            await _context.SaveChangesAsync();

            return _mapper.Map<TelefoneResponseDTO>(telefone);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var telefone = await _context.Telefones.FindAsync(id);
            if (telefone == null) return false;

            _context.Telefones.Remove(telefone);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
