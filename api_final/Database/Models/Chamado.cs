using System;
using System.Collections.Generic;

namespace api_final.Database.Models;

public partial class Chamado
{
    public int IdChamado { get; set; }

    public string DescricaoChamado { get; set; } = null!;

    public string StatusChamado { get; set; } = null!;

    public string? TipoChamado { get; set; }

    public string? DepartamentoChamado { get; set; }

    public int? IdCliente { get; set; }

    public int? IdResponsavel { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Responsavel? IdResponsavelNavigation { get; set; }
}
