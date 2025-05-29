using System;
using System.Collections.Generic;

namespace api_final.Database.Models;

public partial class Email
{
    public int IdEmail { get; set; }

    public string EnderecoEmail { get; set; } = null!;

    public int IdCliente { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;
}
