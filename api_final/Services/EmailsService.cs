using api_final.Database.Models;
using api_final.Services.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;



namespace api_final.Services
{
    public class EmailsService
    {

        private readonly ChamadosContext _context;
        private readonly IMapper _mapper;

        public EmailsService(ChamadosContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<EmailResponseDTO>> GetAllAsync()
        {
            var emails = await _context.Emails.ToListAsync();
            return _mapper.Map<List<EmailResponseDTO>>(emails);
        }

        public async Task<EmailResponseDTO?> GetByIdAsync(int id)
        {
            var email = await _context.Emails.FindAsync(id);
            return email == null ? null : _mapper.Map<EmailResponseDTO>(email);
        }

        public async Task<EmailResponseDTO> CreateAsync(EmailRequestDTO dto)
        {
            var clienteExiste = await _context.Clientes.AnyAsync(c => c.IdCliente == dto.IdCliente);
            if (!clienteExiste)
                throw new KeyNotFoundException("Cliente não encontrado.");

            var email = _mapper.Map<Email>(dto);
            _context.Emails.Add(email);
            await _context.SaveChangesAsync();

            return _mapper.Map<EmailResponseDTO>(email);
        }

        public async Task<EmailResponseDTO?> UpdateAsync(int id, EmailRequestDTO dto)
        {
            var email = await _context.Emails.FindAsync(id);
            if (email == null) return null;

            var clienteExiste = await _context.Clientes.AnyAsync(c => c.IdCliente == dto.IdCliente);
            if (!clienteExiste) return null;

            _mapper.Map(dto, email);
            await _context.SaveChangesAsync();

            return _mapper.Map<EmailResponseDTO>(email);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var email = await _context.Emails.FindAsync(id);
            if (email == null) return false;

            _context.Emails.Remove(email);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
