using System;
using api_clientes.Database.Models;
using api_clientes.Services.DTOs;

namespace api_clientes.Services.Parses
{
    public class ClienteParser
    {
        // função estática auto-instancia um objeto
        public static TbCliente ToTbCliente(CriarClienteDTO dto)
        {
            //instanciando
            TbCliente novoCliente = new();

            //passando o que vem no dto que é as colunas da table cliente para o novoCliente que foi instanciado
            novoCliente.Nome = dto.Nome;
            novoCliente.Telefone = dto.Telefone;
            novoCliente.Nascimento = dto.Nascimento;
            novoCliente.Documento = dto.Documento;
            novoCliente.Tipodoc = dto.Tipodoc;
            novoCliente.Criadoem = DateTime.Now.ToUniversalTime();
            novoCliente.Alteradoem = novoCliente.Criadoem;

            return novoCliente;
        }

        public static ClienteDTO ToClienteDTO(TbCliente cliente)
        {
            ClienteDTO Response = new();

            Response.Id = cliente.Id;
            Response.Nome = cliente.Nome;
            Response.Criadoem = cliente.Criadoem;
            Response.Alteradoem = cliente.Alteradoem;
            Response.Telefone = cliente.Telefone;
            Response.Documento = cliente.Documento;
            Response.Nascimento = cliente.Nascimento;
            Response.Tipodoc = cliente.Tipodoc;

            return Response;
        }
    }
}

