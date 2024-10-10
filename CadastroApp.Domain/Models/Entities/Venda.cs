using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroApp.Domain.Models.Entities
{
    public class Venda
    {
        public int Id { get; set; }
        public DateTime DataEmissao { get; set; }
        public Cliente Cliente { get; set; }
        public List<VendaItem> VendaItens { get; set; }
    }
}
