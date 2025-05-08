using System;
namespace api_clientes.Services.DTOs
{

	public class CriarClienteDTO
	{
        public string Nome { get; set; }

        public DateTime? Nascimento { get; set; }

        public string Telefone { get; set; }

        public string Documento { get; set; }

        public int Tipodoc { get; set; }
    }

	public class ClienteDTO
	{
        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime? Nascimento { get; set; }

        public string Telefone { get; set; }

        public string Documento { get; set; }

        public int Tipodoc { get; set; }

        public DateTime Criadoem { get; set; }

        public DateTime Alteradoem { get; set; }
    }
}

