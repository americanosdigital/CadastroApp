using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadastroApp.Domain.Models.Enums;

namespace CadastroApp.Domain.Models.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        public string Nome { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public Endereco Endereco { get; set; }
        public List<Contato> Contatos { get; set; }
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
