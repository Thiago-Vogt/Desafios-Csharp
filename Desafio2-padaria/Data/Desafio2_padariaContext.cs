using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Desafio2_padaria.Models;

namespace Desafio2_padaria.Data
{
    public class Desafio2_padariaContext : DbContext
    {
        public Desafio2_padariaContext (DbContextOptions<Desafio2_padariaContext> options)
            : base(options)
        {
        }

        public DbSet<Desafio2_padaria.Models.Produto> Produto { get; set; } = default!;
        public DbSet<Desafio2_padaria.Models.Cliente> Cliente { get; set; } = default!;
        public DbSet<Desafio2_padaria.Models.Venda> Venda { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar a relação muitos-para-muitos entre Venda e Produto
            modelBuilder.Entity<Venda>()
                .HasMany(v => v.Produtos)
                .WithMany(p => p.Vendas)
                .UsingEntity<Dictionary<string, object>>(
                    "ProdutoVenda", // Nome da tabela de junção
                    j => j.HasOne<Produto>().WithMany().HasForeignKey("ProdutoId"),
                    j => j.HasOne<Venda>().WithMany().HasForeignKey("VendaId"));
        }
    }
}
