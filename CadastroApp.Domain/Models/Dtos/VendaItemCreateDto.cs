using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroApp.Domain.Models.Dtos
{
    public class VendaItemCreateDto
    {
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }
}
