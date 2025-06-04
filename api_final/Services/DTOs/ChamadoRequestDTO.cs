
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
