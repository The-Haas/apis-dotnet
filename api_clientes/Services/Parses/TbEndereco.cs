using api_clientes.Database.Models;
using api_clientes.Services.DTOs;

public static void AtualizarTbEndereco(TbEndereco endereco, AtualizarEnderecoDTO dto)
{
    endereco.Cep = dto.Cep;
    endereco.Logradouro = dto.Logradouro;
    endereco.Numero = dto.Numero;
    endereco.Complemento = dto.Complemento;
    endereco.Bairro = dto.Bairro;
    endereco.Cidade = dto.Cidade;
    endereco.Uf = dto.Uf;
    endereco.Clienteid = dto.ClienteId;
    endereco.Status = dto.Status;
}
