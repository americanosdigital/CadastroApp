using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroApp.Domain.Models.Dtos
{
    public class VendaItemReadDto
    {
        public int Id { get; set; }
        public ProdutoReadDto Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoVenda { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
