using CadastroApp.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroApp.Domain.Models.Dtos
{
    public class ClienteReadDto
    {
        public int Id { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        public string Nome { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public EnderecoDto Endereco { get; set; }
        public List<ContatoDto> Contatos { get; set; }

        // Dados Pessoa Física
        public string? CPF { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? Identidade { get; set; }

        // Dados Pessoa Jurídica
        public string? CNPJ { get; set; }
        public string? NomeFantasia { get; set; }
        public string? InscricaoEstadual { get; set; }
        public string? InscricaoMunicipal { get; set; }
    }
}
