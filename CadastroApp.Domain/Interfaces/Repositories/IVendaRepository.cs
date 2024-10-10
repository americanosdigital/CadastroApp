using CadastroApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroApp.Domain.Interfaces.Repositories
{
    public interface IVendaRepository
    {
        Task<Venda> CreateAsync(Venda venda);
        Task<Venda> UpdateAsync(Venda venda);
        Task<bool> DeleteAsync(int id);
        Task<Venda> GetByIdAsync(int id);
        Task<IEnumerable<Venda>> GetAllAsync();
    }
}
