using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CadastroApp.Domain.Interfaces.Repositories;
using CadastroApp.Domain.Models.Entities;
using CadastroApp.Infra.Data.Contexts;

namespace CadastroApp.Infra.Data.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        private readonly DataContext _context;

        public VendaRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Venda> CreateAsync(Venda venda)
        {
            _context.Vendas.Add(venda);
            await _context.SaveChangesAsync();
            return venda;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var venda = await _context.Vendas.FindAsync(id);
            if (venda == null)
                return false;

            _context.Vendas.Remove(venda);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Venda>> GetAllAsync()
        {
            return await _context.Vendas
                .Include(v => v.Cliente)
                .Include(v => v.VendaItens)
                    .ThenInclude(i => i.Produto)
                .ToListAsync();
        }

        public async Task<Venda> GetByIdAsync(int id)
        {
            return await _context.Vendas
                .Include(v => v.Cliente)
                .Include(v => v.VendaItens)
                    .ThenInclude(i => i.Produto)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<Venda> UpdateAsync(Venda venda)
        {
            _context.Vendas.Update(venda);
            await _context.SaveChangesAsync();
            return venda;
        }
    }
}
