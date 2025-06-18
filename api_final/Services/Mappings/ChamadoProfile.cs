
// Aqui define o mapeamento entre os DTOs e a entidade Chamado usando AutoMapper.
// O AutoMapper substitui os parsers
// Esse mapping é usado pelos serviços e controllers para converter dados entre a API e o modelo do banco
using AutoMapper;
using api_final.Database.Models;
using api_final.DTOs;

namespace api_final.Services.DTOs
{
    public class ChamadoProfile : Profile
    {
        public ChamadoProfile()
        {
            CreateMap<ChamadoRequestDTO, Chamado>();
            CreateMap<Chamado, ChamadoResponseDTO>();
        }
    }
}
