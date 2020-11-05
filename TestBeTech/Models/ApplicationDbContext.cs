using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace TestBeTech.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductStorage> ProductStorages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductStorage>()
                .HasKey(ps => new { ps.ProductId, ps.StorageId });
            modelBuilder.Entity<ProductStorage>()
                .HasOne(ps => ps.Product)
                .WithMany(p => p.ProductStorages)
                .HasForeignKey(ps => ps.ProductId);
            modelBuilder.Entity<ProductStorage>()
                .HasOne(ps => ps.Storage)
                .WithMany(s => s.ProductStorages)
                .HasForeignKey(ps => ps.StorageId);

            modelBuilder.Entity<Product>()
               .HasMany(ps => ps.ProductStorages)
               .WithOne(p => p.Product)
               .HasForeignKey(ps => ps.ProductId);
        }
    }
}
