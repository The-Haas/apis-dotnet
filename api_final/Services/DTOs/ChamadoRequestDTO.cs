
// DTO é usado para transferir dados entre cliente e API de forma controlada sem expor dados sensíveis.
// DTOs separados para Request e Response ajuda a diferenciar os dados recebidos dos enviados,  
// Quem usa esses DTOs são os controllers da API ao receber e enviar dados.
namespace api_final.DTOs
{
    public class ChamadoRequestDTO
    {
        public string DescricaoChamado { get; set; }
        public string StatusChamado { get; set; }
        public string? TipoChamado { get; set; }
        public string? DepartamentoChamado { get; set; }
        public int? IdCliente { get; set; }
        public int? IdResponsavel { get; set; }
    }
}
