using System;
using System.Collections.Generic;

namespace api_final.Database.Models;

public partial class Responsavel
{
    public int IdResponsavel { get; set; }

    public string NomeResponsavel { get; set; } = null!;

    public virtual ICollection<Chamado> Chamados { get; set; } = new List<Chamado>();
}
