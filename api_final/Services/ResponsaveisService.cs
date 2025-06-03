using AutoMapper;
using Microsoft.EntityFrameworkCore;
using api_final.Database.Models;
using api_final.DTOs;

namespace api_final.Services
{
    public class ResponsaveisService
    {
        private readonly ChamadosContext _context;
        private readonly IMapper _mapper;

        public ResponsaveisService(ChamadosContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ResponsavelResponseDTO>> GetAllAsync()
        {
            var responsaveis = await _context.Responsavels.ToListAsync();
            return _mapper.Map<List<ResponsavelResponseDTO>>(responsaveis);
        }

        public async Task<ResponsavelResponseDTO?> GetByIdAsync(int id)
        {
            var responsavel = await _context.Responsavels.FindAsync(id);
            return responsavel == null ? null : _mapper.Map<ResponsavelResponseDTO>(responsavel);
        }

        public async Task<ResponsavelResponseDTO> CreateAsync(ResponsavelRequestDTO dto)
        {
            var entity = _mapper.Map<Responsavel>(dto);
            _context.Responsavels.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<ResponsavelResponseDTO>(entity);
        }

        public async Task<bool> UpdateAsync(int id, ResponsavelRequestDTO dto)
        {
            var entity = await _context.Responsavels.FindAsync(id);
            if (entity == null) return false;

            _mapper.Map(dto, entity);
            _context.Responsavels.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Responsavels.FindAsync(id);
            if (entity == null) return false;

            _context.Responsavels.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
