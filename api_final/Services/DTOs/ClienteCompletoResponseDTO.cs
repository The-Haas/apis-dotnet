namespace api_final.DTOs
{
    public class ClienteCompletoResponseDTO
    {
        public string RazaoSocialCliente { get; set; }
        public string NomeFantasiaCliente { get; set; }
        public string CnpjCliente { get; set; }
        public string IeCliente { get; set; }
        public string EnderecoCliente { get; set; }

        public List<TelefoneDTO> Telefones { get; set; }
        public List<EmailDTO> Emails { get; set; }
    }

    public class TelefoneDTO
    {
        public string NumeroTelefone { get; set; }
    }

    public class EmailDTO
    {
        public string EnderecoEmail { get; set; }
    }
}
