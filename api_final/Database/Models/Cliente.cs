using System;
using System.Collections.Generic;

namespace api_final.Database.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string RazaoSocialCliente { get; set; } = null!;

    public string NomeFantasiaCliente { get; set; } = null!;

    public string CnpjCliente { get; set; } = null!;

    public long IeCliente { get; set; }

    public string? EnderecoCliente { get; set; }

    public virtual ICollection<Chamado> Chamados { get; set; } = new List<Chamado>();

    public virtual ICollection<Email> Emails { get; set; } = new List<Email>();

    public virtual ICollection<Telefone> Telefones { get; set; } = new List<Telefone>();
}
