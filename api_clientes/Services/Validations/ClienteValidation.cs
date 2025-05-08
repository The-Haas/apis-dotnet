using System;
using System.Linq;
using api_clientes.Services.DTOs;
using api_clientes.Services.Exceptions;

namespace api_clientes.Services.Validations
{
	public class ClienteValidation
	{
		public static void ValidarCriarCliente(CriarClienteDTO criarClienteDTO)
		{
			if (string.IsNullOrEmpty(criarClienteDTO.Nome))
				throw new BadRequestException("Nome é Obrigatório");

            if (string.IsNullOrEmpty(criarClienteDTO.Documento))
                throw new BadRequestException("Documento é Obrigatório");

			if (!new[] { 0, 1, 2, 3, 99 }.Contains(criarClienteDTO.Tipodoc))
				throw new BadRequestException("Tipo de Documento não Suportado");
        }
	}
}

