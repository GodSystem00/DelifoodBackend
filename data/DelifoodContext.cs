using Delifood.Models;
using Microsoft.EntityFrameworkCore;
namespace Delifood.Data
{
 public class DelifoodContext : DbContext
 {
 public DelifoodContext(DbContextOptions<DelifoodContext> options) : base(options)
 {
 }
 public DbSet<Cliente> Clientes { get; set; }
 public DbSet<Compra> Compras { get; set; }
 public DbSet<CompraMercado> CompraMercados { get; set; }
  public DbSet<Mercado> Mercados { get; set; }
   public DbSet<Producto> Productos { get; set; }
    public DbSet<Vendedor> Vendedors { get; set; }
 protected override void OnModelCreating(ModelBuilder modelBuilder) {
    modelBuilder.Entity<Cliente>().ToTable("clientes");
    modelBuilder.Entity<Compra>().ToTable("compras");
    modelBuilder.Entity<CompraMercado>().ToTable("compramercados");
    modelBuilder.Entity<Mercado>().ToTable("mercados");
    modelBuilder.Entity<Producto>().ToTable("productos");
    modelBuilder.Entity<Vendedor>().ToTable("vendedors");
 }
 }
}
