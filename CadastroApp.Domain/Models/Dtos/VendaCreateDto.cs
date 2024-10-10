using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroApp.Domain.Models.Dtos
{
    public class VendaCreateDto
    {
        public int ClienteId { get; set; }
        public List<VendaItemCreateDto> Itens { get; set; }
    }
}
