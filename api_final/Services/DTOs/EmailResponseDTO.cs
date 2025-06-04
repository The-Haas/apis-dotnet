namespace api_final.Services.DTOs
{
    public class EmailResponseDTO
    {
        public int IdEmail { get; set; }
        public string EnderecoEmail { get; set; } = null!;
        public int IdCliente { get; set; }
    }
}
