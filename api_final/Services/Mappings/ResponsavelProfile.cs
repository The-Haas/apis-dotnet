using AutoMapper;
using api_final.DTOs;
using api_final.Database.Models;

namespace api_final.Mappings
{
    public class ResponsavelProfile : Profile
    {
        public ResponsavelProfile()
        {
            CreateMap<Responsavel, ResponsavelResponseDTO>();
            CreateMap<ResponsavelRequestDTO, Responsavel>();
        }
    }
}
