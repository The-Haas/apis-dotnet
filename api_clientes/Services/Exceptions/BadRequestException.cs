using System;
namespace api_clientes.Services.Exceptions
{
	public class BadRequestException : Exception
	{
		public BadRequestException(string message) : base(message)
		{

		}
	}
}

