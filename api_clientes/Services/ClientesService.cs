using System;
using System.Collections.Generic;
using System.Linq;
using api_clientes.Database.Models;
using api_clientes.Services.DTOs;
using api_clientes.Services.Exceptions;
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

        public List<ClienteDTO> ListarTodos()
        {
            var clientes = _dbcontext.TbClientes.ToList();

            var response = clientes.Select(c => ClienteParser.ToClienteDTO(c)).ToList();

            return response;
        }

        public ClienteDTO BuscarPorId(int id)
        {
            var cliente = _dbcontext.TbClientes.FirstOrDefault(c => c.Id == id);

            if (cliente == null)
                throw new BadRequestException("Cliente não encontrado");

            return ClienteParser.ToClienteDTO(cliente);
        }

        public ClienteDTO Atualizar(int id, CriarClienteDTO dto)
        {
            var cliente = _dbcontext.TbClientes.FirstOrDefault(c => c.Id == id);

            if (cliente == null)
                throw new BadRequestException("Cliente não encontrado");

            ClienteValidation.ValidarCriarCliente(dto);

            // Atualiza os campos
            cliente.Nome = dto.Nome;
            cliente.Nascimento = dto.Nascimento;
            cliente.Telefone = dto.Telefone;
            cliente.Documento = dto.Documento;
            cliente.Tipodoc = dto.Tipodoc;
            cliente.Alteradoem = DateTime.UtcNow;

            _dbcontext.SaveChanges();

            return ClienteParser.ToClienteDTO(cliente);
        }

        public void Remover(int id)
        {
            var cliente = _dbcontext.TbClientes.FirstOrDefault(c => c.Id == id);

            if (cliente == null)
                throw new BadRequestException("Cliente não encontrado");

            _dbcontext.TbClientes.Remove(cliente);
            _dbcontext.SaveChanges();
        }

        public ClienteDTO AtualizarParcialmente(int id, AtualizarClienteDTO dto)
        {
            var cliente = _dbcontext.TbClientes.FirstOrDefault(c => c.Id == id);

            if (cliente == null)
                throw new BadRequestException("Cliente não encontrado");

            // Atualiza apenas se o campo tiver valor
            if (!string.IsNullOrWhiteSpace(dto.Nome))
                cliente.Nome = dto.Nome;

            if (dto.Nascimento.HasValue)
                cliente.Nascimento = dto.Nascimento;

            if (!string.IsNullOrWhiteSpace(dto.Telefone))
                cliente.Telefone = dto.Telefone;

            if (!string.IsNullOrWhiteSpace(dto.Documento))
                cliente.Documento = dto.Documento;

            if (dto.Tipodoc.HasValue)
            {
                if (!new[] { 0, 1, 2, 3, 99 }.Contains(dto.Tipodoc.Value))
                    throw new BadRequestException("Tipo de Documento não Suportado");

                cliente.Tipodoc = dto.Tipodoc.Value;
            }

            cliente.Alteradoem = DateTime.UtcNow;

            _dbcontext.SaveChanges();

            return ClienteParser.ToClienteDTO(cliente);
        }
    }
}