using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace Store.Models
{
    public class ProductContext : DbContext
    {
        public DbSet<Products> Products { get; set; }
        public DbSet<Catalog> Catalog { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Shopdb;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catalog>()
                    .HasMany(c => c.Product)
                    .WithMany(s => s.Catalogs)
                    .UsingEntity(j => j.ToTable("CatalogProducts"));
        }
    }
}
