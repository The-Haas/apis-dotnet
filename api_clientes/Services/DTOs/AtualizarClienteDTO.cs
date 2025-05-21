using System;

namespace api_clientes.Services.DTOs
{
    public class AtualizarClienteDTO
    {
        public string? Nome { get; set; }
        public DateTime? Nascimento { get; set; }
        public string? Telefone { get; set; }
        public string? Documento { get; set; }
        public int? Tipodoc { get; set; }
    }
}
