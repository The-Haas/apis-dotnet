using AutoMapper;
using api_final.Services.DTOs;
using api_final.Database.Models;

namespace api_final.Mappings
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            //Mapeia automaticamente os campos da entidade Cliente para o DTO de resposta
            CreateMap<Cliente, ClienteResponseDTO>();
            //Mapeia do DTO de requisição para a entidade Cliente
            CreateMap<ClienteRequestDTO, Cliente>();
        }
    }
}
