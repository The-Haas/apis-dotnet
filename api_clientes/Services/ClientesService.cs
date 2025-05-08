using System;
using api_clientes.Database.Models;
using api_clientes.Services.DTOs;
using api_clientes.Services.Parses;
using api_clientes.Services.Validations;

namespace api_clientes.Services
{
	public class ClientesService
	{

		private readonly ClientesContext _dbcontext;

		public ClientesService(ClientesContext dbcontext)
		{
			_dbcontext = dbcontext;
		}


		public ClienteDTO Criar(CriarClienteDTO dto)
		{

			ClienteValidation.ValidarCriarCliente(dto);

			TbCliente novoCliente = ClienteParser.ToTbCliente(dto);


			_dbcontext.TbClientes.Add(novoCliente);
			_dbcontext.SaveChanges();


			return ClienteParser.ToClienteDTO(novoCliente);

        }


    }
}