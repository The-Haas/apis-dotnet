namespace api_final.DTOs
{
    public class ChamadoCompletoResponseDTO
    {
        public string DescricaoChamado { get; set; }
        public string StatusChamado { get; set; }
        public string? TipoChamado { get; set; }
        public string? DepartamentoChamado { get; set; }

        public ClienteSemIdDTO? Cliente { get; set; }
        public ResponsavelSemIdDTO? Responsavel { get; set; }
    }

    public class ClienteSemIdDTO
    {
        public string RazaoSocialCliente { get; set; }
        public string NomeFantasiaCliente { get; set; }
        public string CnpjCliente { get; set; }
        public string IeCliente { get; set; }
        public string EnderecoCliente { get; set; }

        public List<TelefoneSemIdDTO> Telefones { get; set; }
        public List<EmailSemIdDTO> Emails { get; set; }
    }

    public class ResponsavelSemIdDTO
    {
        public string NomeResponsavel { get; set; }
    }

    public class TelefoneSemIdDTO
    {
        public string NumeroTelefone { get; set; }
    }

    public class EmailSemIdDTO
    {
        public string EnderecoEmail { get; set; }
    }
}
