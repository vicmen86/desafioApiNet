using Microsoft.EntityFrameworkCore;
using apiNet.Models;
namespace ApiNet;
public class ProductsContext : DbContext
{
  public DbSet<TipoProducto> TipoProductos { get; set; }
  public DbSet<Producto> Productos { get; set; }
  public DbSet<Stock> Stocks { get; set; }

  public ProductsContext(DbContextOptions<ProductsContext> options) : base(options) { }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    //List<Producto> productos = new List<Producto>();
    modelBuilder.Entity<TipoProducto>(tipoProducto =>
    {
      tipoProducto.ToTable("TipoProducto");
      tipoProducto.HasKey(t => t.IdTipoProducto);
      tipoProducto.Property(t => t.Descripcion).IsRequired().HasMaxLength(150);

    });

    modelBuilder.Entity<Producto>(producto =>
      {
        producto.ToTable("Producto");
        producto.HasKey(p => p.IdProducto);
        producto.HasOne(p => p.TipoProducto).WithMany(p => p.Producto).HasForeignKey(p => p.TipoProductoId);
        producto.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
        producto.Property(p => p.Precio);

      });
    modelBuilder.Entity<Stock>(stock =>
   {
        stock.ToTable("Stock");
        stock.HasKey(s => s.IdStock);
        stock.HasOne(s => s.Producto).WithMany(s => s.Stock).HasForeignKey(s => s.ProductoId);
        stock.Property(s => s.Descripcion).HasMaxLength(150);
        stock.Property(s => s.Cantidad);

   });
  }

}