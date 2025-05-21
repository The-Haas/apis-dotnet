using System;

namespace api_clientes.Services.DTOs
{
    public class CriarEnderecoDTO
    {
        public int Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public int ClienteId { get; set; }
    }

    public class EnderecoDTO
    {
        public int Id { get; set; }
        public int Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public int ClienteId { get; set; }
        public int Status { get; set; }
    }
}
