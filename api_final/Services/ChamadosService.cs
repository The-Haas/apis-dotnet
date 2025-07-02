
// Service implementa a lógica de negócio para gerenciar chamados, usando o contexto do banco e AutoMapper.
// Ele faz operações CRUD (criar, ler, atualizar, deletar) no banco, convertendo dados entre entidades e DTOs.
// Os controllers chamam esse serviço para executar as ações solicitadas pela API.

// Bibliotecas Usadas
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using api_final.Database.Models;
using api_final.DTOs;

namespace api_final.Services
{
    public class ChamadoService
    {
        // pra acessar as tabelas do BD
        private readonly ChamadosContext _context;

        // mapper para converter entre entidades e DTOs
        private readonly IMapper _mapper;

        // Construtor que recebe o contexto e o mapper
        public ChamadoService(ChamadosContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        // Assync para aguardar, Task é tipo a Promisses do Node, dizendo que vai retornar alguma coisa
        public async Task<List<ChamadoResponseDTO>> GetAllAsync()
        {
            // Await para esperar concluir o select
            var chamados = await _context.Chamados.ToListAsync();

            // Vai retornar os dados mapeados e com as propriedades definidas no Chamado Response DTO
            return _mapper.Map<List<ChamadoResponseDTO>>(chamados);
        }

        public async Task<ChamadoResponseDTO?> GetByIdAsync(int id)
        {
            var chamado = await _context.Chamados.FindAsync(id);
            return chamado == null ? null : _mapper.Map<ChamadoResponseDTO>(chamado);
        }

        public async Task<ChamadoResponseDTO?> CreateAsync(ChamadoRequestDTO dto)
        {
            if (dto.IdCliente.HasValue && !await _context.Clientes.AnyAsync(c => c.IdCliente == dto.IdCliente))
                return null;

            if (dto.IdResponsavel.HasValue && !await _context.Responsavels.AnyAsync(r => r.IdResponsavel == dto.IdResponsavel))
                return null;

            var chamado = _mapper.Map<Chamado>(dto);
            _context.Chamados.Add(chamado);
            await _context.SaveChangesAsync();
            return _mapper.Map<ChamadoResponseDTO>(chamado);
        }

        public async Task<bool> UpdateAsync(int id, ChamadoRequestDTO dto)
        {
            var chamado = await _context.Chamados.FindAsync(id);
            if (chamado == null) return false;

            if (dto.IdCliente.HasValue && !await _context.Clientes.AnyAsync(c => c.IdCliente == dto.IdCliente))
                return false;

            if (dto.IdResponsavel.HasValue && !await _context.Responsavels.AnyAsync(r => r.IdResponsavel == dto.IdResponsavel))
                return false;

            _mapper.Map(dto, chamado);
            _context.Chamados.Update(chamado);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var chamado = await _context.Chamados.FindAsync(id);
            if (chamado == null) return false;

            _context.Chamados.Remove(chamado);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
