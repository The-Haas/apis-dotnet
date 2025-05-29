using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace api_final.Database.Models;

public partial class ChamadosContext : DbContext
{
    public ChamadosContext()
    {
    }

    public ChamadosContext(DbContextOptions<ChamadosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Chamado> Chamados { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Email> Emails { get; set; }

    public virtual DbSet<Responsavel> Responsavels { get; set; }

    public virtual DbSet<Telefone> Telefones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=chamados;Username=postgres;Password=9715");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chamado>(entity =>
        {
            entity.HasKey(e => e.IdChamado).HasName("chamado_pkey");

            entity.ToTable("chamado");

            entity.Property(e => e.IdChamado)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_chamado");
            entity.Property(e => e.DepartamentoChamado)
                .HasMaxLength(50)
                .HasColumnName("departamento_chamado");
            entity.Property(e => e.DescricaoChamado)
                .HasMaxLength(3000)
                .HasColumnName("descricao_chamado");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdResponsavel).HasColumnName("id_responsavel");
            entity.Property(e => e.StatusChamado)
                .HasMaxLength(20)
                .HasColumnName("status_chamado");
            entity.Property(e => e.TipoChamado)
                .HasMaxLength(50)
                .HasColumnName("tipo_chamado");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Chamados)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("chamado_id_cliente_fkey");

            entity.HasOne(d => d.IdResponsavelNavigation).WithMany(p => p.Chamados)
                .HasForeignKey(d => d.IdResponsavel)
                .HasConstraintName("chamado_id_responsavel_fkey");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("cliente_pkey");

            entity.ToTable("cliente");

            entity.Property(e => e.IdCliente)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_cliente");
            entity.Property(e => e.CnpjCliente)
                .HasMaxLength(14)
                .HasColumnName("cnpj_cliente");
            entity.Property(e => e.EnderecoCliente)
                .HasMaxLength(300)
                .HasColumnName("endereco_cliente");
            entity.Property(e => e.IeCliente).HasColumnName("ie_cliente");
            entity.Property(e => e.NomeFantasiaCliente)
                .HasMaxLength(200)
                .HasColumnName("nome_fantasia_cliente");
            entity.Property(e => e.RazaoSocialCliente)
                .HasMaxLength(200)
                .HasColumnName("razao_social_cliente");
        });

        modelBuilder.Entity<Email>(entity =>
        {
            entity.HasKey(e => e.IdEmail).HasName("email_pkey");

            entity.ToTable("email");

            entity.Property(e => e.IdEmail)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_email");
            entity.Property(e => e.EnderecoEmail)
                .HasMaxLength(200)
                .HasColumnName("endereco_email");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Emails)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("email_id_cliente_fkey");
        });

        modelBuilder.Entity<Responsavel>(entity =>
        {
            entity.HasKey(e => e.IdResponsavel).HasName("responsavel_pkey");

            entity.ToTable("responsavel");

            entity.Property(e => e.IdResponsavel)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_responsavel");
            entity.Property(e => e.NomeResponsavel)
                .HasMaxLength(200)
                .HasColumnName("nome_responsavel");
        });

        modelBuilder.Entity<Telefone>(entity =>
        {
            entity.HasKey(e => e.IdTelefone).HasName("telefone_pkey");

            entity.ToTable("telefone");

            entity.Property(e => e.IdTelefone)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_telefone");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.NumeroTelefone).HasColumnName("numero_telefone");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Telefones)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("telefone_id_cliente_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
