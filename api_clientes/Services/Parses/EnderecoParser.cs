using api_clientes.Database.Models;
using api_clientes.Services.DTOs;

namespace api_clientes.Services.Parses
{
    public class EnderecoParser
    {
        public static TbEndereco ToTbEndereco(CriarEnderecoDTO dto)
        {
            return new TbEndereco
            {
                Cep = dto.Cep,
                Logradouro = dto.Logradouro,
                Numero = dto.Numero,
                Complemento = dto.Complemento,
                Bairro = dto.Bairro,
                Cidade = dto.Cidade,
                Uf = dto.Uf,
                Clienteid = dto.ClienteId,
                Status = 1
            };
        }

        public static EnderecoDTO ToEnderecoDTO(TbEndereco endereco)
        {
            return new EnderecoDTO
            {
                Id = endereco.Id,
                Cep = endereco.Cep,
                Logradouro = endereco.Logradouro,
                Numero = endereco.Numero,
                Complemento = endereco.Complemento,
                Bairro = endereco.Bairro,
                Cidade = endereco.Cidade,
                Uf = endereco.Uf,
                ClienteId = endereco.Clienteid,
                Status = endereco.Status
            };
        }

        

    }
}
