using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CadastroApp.Domain.Models.Entities;
using CadastroApp.Domain.Models.Enums;

namespace CadastroApp.Infra.Data.Contexts
{
    public class DataContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }        
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<VendaItem> VendaItens { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações adicionais, se necessário
            base.OnModelCreating(modelBuilder);
        }
    }
}
