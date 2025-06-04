
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
