using AutoMapper;
using api_final.Services.DTOs;
using api_final.Database.Models;

namespace api_final.Mappings
{
    public class TelefoneProfile : Profile
    {
        public TelefoneProfile()
        {
            CreateMap<Telefone, TelefoneResponseDTO>();
            CreateMap<TelefoneRequestDTO, Telefone>();
        }
    }
}
