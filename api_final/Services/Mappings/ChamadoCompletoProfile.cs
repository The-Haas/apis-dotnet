using AutoMapper;
using api_final.Database.Models;
using api_final.DTOs;

namespace api_final.Services.DTOs
{
    public class ChamadoCompletoProfile : Profile
    {
        public ChamadoCompletoProfile()
        {
            CreateMap<Chamado, ChamadoCompletoResponseDTO>()
                .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src.IdClienteNavigation))
                .ForMember(dest => dest.Responsavel, opt => opt.MapFrom(src => src.IdResponsavelNavigation));

            CreateMap<Cliente, ClienteSemIdDTO>();

            CreateMap<Responsavel, ResponsavelSemIdDTO>();

            CreateMap<Telefone, TelefoneSemIdDTO>();

            CreateMap<Email, EmailSemIdDTO>();
        }
    }
}
