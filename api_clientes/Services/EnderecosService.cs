using api_clientes.Database.Models;
using api_clientes.Services.DTOs;
using api_clientes.Services.Exceptions;
using api_clientes.Services.Parses;
using api_clientes.Services.Validations;
using System.Collections.Generic;
using System.Linq;

namespace api_clientes.Services
{
    public class EnderecosService
    {
        private readonly ClientesContext _dbcontext;

        public EnderecosService(ClientesContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public EnderecoDTO Criar(CriarEnderecoDTO dto)
        {
            EnderecoValidation.ValidarCriarEndereco(dto);

            var endereco = EnderecoParser.ToTbEndereco(dto);

            _dbcontext.TbEnderecos.Add(endereco);
            _dbcontext.SaveChanges();

            return EnderecoParser.ToEnderecoDTO(endereco);
        }

        public EnderecoDTO BuscarPorId(int id)
        {
            var endereco = _dbcontext.TbEnderecos.FirstOrDefault(e => e.Id == id);
            if (endereco == null)
                throw new NotFoundException("Endereço não encontrado");

            return EnderecoParser.ToEnderecoDTO(endereco);
        }

        public List<EnderecoDTO> ListarTodos()
        {
            return _dbcontext.TbEnderecos
                .Select(e => EnderecoParser.ToEnderecoDTO(e))
                .ToList();
        }

        public void Deletar(int id)
        {
            var endereco = _dbcontext.TbEnderecos.FirstOrDefault(e => e.Id == id);
            if (endereco == null)
                throw new NotFoundException("Endereço não encontrado");

            _dbcontext.TbEnderecos.Remove(endereco);
            _dbcontext.SaveChanges();
        }

        public EnderecoDTO Atualizar(int id, AtualizarEnderecoDTO dto)
        {
            var endereco = _dbcontext.TbEnderecos.FirstOrDefault(e => e.Id == id);
            if (endereco == null)
                throw new NotFoundException("Endereço não encontrado");

            EnderecoValidation.ValidarCriarEndereco(new CriarEnderecoDTO
            {
                Cep = dto.Cep,
                Logradouro = dto.Logradouro,
                Numero = dto.Numero,
                Complemento = dto.Complemento,
                Bairro = dto.Bairro,
                Cidade = dto.Cidade,
                Uf = dto.Uf,
                ClienteId = dto.ClienteId
            });

            endereco.Cep = dto.Cep;
            endereco.Logradouro = dto.Logradouro;
            endereco.Numero = dto.Numero;
            endereco.Complemento = dto.Complemento;
            endereco.Bairro = dto.Bairro;
            endereco.Cidade = dto.Cidade;
            endereco.Uf = dto.Uf;
            endereco.Clienteid = dto.ClienteId;
            endereco.Status = dto.Status;

            _dbcontext.SaveChanges();

            return EnderecoParser.ToEnderecoDTO(endereco);
        }

        public EnderecoDTO Patch(int id, PatchEnderecoDTO dto)
        {
            var endereco = _dbcontext.TbEnderecos.FirstOrDefault(e => e.Id == id);
            if (endereco == null)
                throw new NotFoundException("Endereço não encontrado");

            if (dto.Cep.HasValue) endereco.Cep = dto.Cep.Value;
            if (!string.IsNullOrWhiteSpace(dto.Logradouro)) endereco.Logradouro = dto.Logradouro;
            if (!string.IsNullOrWhiteSpace(dto.Numero)) endereco.Numero = dto.Numero;
            if (!string.IsNullOrWhiteSpace(dto.Complemento)) endereco.Complemento = dto.Complemento;
            if (!string.IsNullOrWhiteSpace(dto.Bairro)) endereco.Bairro = dto.Bairro;
            if (!string.IsNullOrWhiteSpace(dto.Cidade)) endereco.Cidade = dto.Cidade;
            if (!string.IsNullOrWhiteSpace(dto.Uf)) endereco.Uf = dto.Uf;
            if (dto.ClienteId.HasValue) endereco.Clienteid = dto.ClienteId.Value;
            if (dto.Status.HasValue) endereco.Status = dto.Status.Value;

            _dbcontext.SaveChanges();

            return EnderecoParser.ToEnderecoDTO(endereco);
        }



    }
}
