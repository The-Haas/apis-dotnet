using AutoMapper;
using api_final.Database.Models;
using api_final.Services.DTOs;

namespace api_final.Services.Mapping
{
    public class EmailProfile : Profile
    {
        public EmailProfile()
        {
            CreateMap<Email, EmailResponseDTO>();
            CreateMap<EmailRequestDTO, Email>();
        }
    }
}
