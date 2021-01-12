using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;


namespace Store.Models
{
    public class ProductContext : DbContext
    {
        public DbSet<Products> Product { get; set; }
        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<CatalogProducts> CatalogProduct { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Shopdb;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogProducts>()
                .HasKey(bc => new { bc.ProductId, bc.CatalogId });

            modelBuilder.Entity<CatalogProducts>()
                .HasOne(bc => bc.Product)
                .WithMany(b => b.CatalogProduct)
                .HasForeignKey(bc => bc.ProductId);

            modelBuilder.Entity<CatalogProducts>()
                .HasOne(bc => bc.Catalog)
                .WithMany(c => c.CatalogProduct)
                .HasForeignKey(bc => bc.CatalogId);

            modelBuilder.Entity<Products>().ToTable("Products");
            modelBuilder.Entity<Products>().Property(u => u.Name).HasColumnName("product_name");
            modelBuilder.Entity<Products>().Property(u => u.Id).HasColumnName("Id");
            modelBuilder.Entity<Catalog>().ToTable("Catalog");
            modelBuilder.Entity<Catalog>().Property(u => u.Name).HasColumnName("catalog_name");
            modelBuilder.Entity<Catalog>().Property(u => u.Id).HasColumnName("Id");
            modelBuilder.Entity<CatalogProducts>().ToTable("CatalogProducts");
            modelBuilder.Entity<CatalogProducts>().Property(u => u.CatalogId).HasColumnName("catalog_id");
            modelBuilder.Entity<CatalogProducts>().Property(u => u.ProductId).HasColumnName("product_id");
        }
    }
}
