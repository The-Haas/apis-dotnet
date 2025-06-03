using AutoMapper;
using api_final.Services.DTOs;
using api_final.Database.Models;

namespace api_final.Mappings
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<Cliente, ClienteResponseDTO>();
            CreateMap<ClienteRequestDTO, Cliente>();
        }
    }
}
