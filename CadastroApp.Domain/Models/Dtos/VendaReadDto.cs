using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroApp.Domain.Models.Dtos
{
    public class VendaReadDto
    {
        public int Id { get; set; }
        public DateTime DataEmissao { get; set; }
        public ClienteReadDto Cliente { get; set; }
        public List<VendaItemReadDto> Itens { get; set; }
    }
}
