using Adalio.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace Adalio.Data
{
    
    public class DataContext : DbContext
    {
        
        public DataContext(DbContextOptions<DataContext> options) : base(options) {
            
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Adalio.Domain.Models.Client> Clients { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Importer> Importers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> orderLines { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(10, 2)");
        }

    }
}
