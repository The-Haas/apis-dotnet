using System;
namespace api_final.Services.DTOs
{
    public class ClienteRequestDTO
    {
        public string RazaoSocialCliente { get; set; }
        public string NomeFantasiaCliente { get; set; }
        public string CnpjCliente { get; set; }
        public long IeCliente { get; set; }
        public string? EnderecoCliente { get; set; }
    }
}