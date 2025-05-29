using System;

namespace api_final.DTOs
{
    public class ChamadoDTO
    {
        public int IdChamado { get; set; }           // id_chamado
        public string DescricaoChamado { get; set; } // descricao_chamado
        public string StatusChamado { get; set; }    // status_chamado
        public string TipoChamado { get; set; }      // tipo_chamado (pode ser null)
        public string DepartamentoChamado { get; set; } // departamento_chamado (pode ser null)
        public int? IdCliente { get; set; }           // id_cliente (nullable)
        public int? IdResponsavel { get; set; }       // id_responsavel (nullable)
    }
}