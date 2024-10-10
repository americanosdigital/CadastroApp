using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroApp.Domain.Models.Dtos
{
    public class ContatoDto
    {
        public string Nome { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
    }
}
