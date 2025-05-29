using System;
using System.Collections.Generic;

namespace api_final.Database.Models;

public partial class Telefone
{
    public int IdTelefone { get; set; }

    public long NumeroTelefone { get; set; }

    public int IdCliente { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;
}
