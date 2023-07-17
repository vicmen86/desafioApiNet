using Microsoft.EntityFrameworkCore;
using ApiNet.Models;
namespace ApiNet;
public class ProductsContext : DbContext
{
  public DbSet<TipoProducto> TipoProductos { get; set; }
  public DbSet<Producto> Productos { get; set; }
  public DbSet<Stock> Stocks { get; set; }

  public ProductsContext(DbContextOptions<ProductsContext> options) : base(options) { }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    List<TipoProducto> tipoProductosIniciales = new List<TipoProducto>();
    tipoProductosIniciales.Add(new TipoProducto() { IdTipoProducto = 1, Descripcion = "Caño estructural" });
    tipoProductosIniciales.Add(new TipoProducto() { IdTipoProducto = 2, Descripcion = "Hierros" });
    tipoProductosIniciales.Add(new TipoProducto() { IdTipoProducto = 3, Descripcion = "Metales" });
    tipoProductosIniciales.Add(new TipoProducto() { IdTipoProducto = 4, Descripcion = "Aluminio" });
    tipoProductosIniciales.Add(new TipoProducto() { IdTipoProducto = 5, Descripcion = "Perfiles IPN" });
    tipoProductosIniciales.Add(new TipoProducto() { IdTipoProducto = 6, Descripcion = "Chapas" });


    modelBuilder.Entity<TipoProducto>(tipoProducto =>
    {
      tipoProducto.ToTable("TipoProducto");
      tipoProducto.HasKey(t => t.IdTipoProducto);
      tipoProducto.Property(t => t.Descripcion).IsRequired().HasMaxLength(150);
      tipoProducto.HasData(tipoProductosIniciales);

    });
    List<Producto> productosIniciales = new List<Producto>();
    productosIniciales.Add(new Producto() { IdProducto = 1, TipoProductoId = 1, Nombre = "Caño cuadrado", Detalle = "Caño 40x40x1.6 x 12m", Precio = 5250 });
    productosIniciales.Add(new Producto() { IdProducto = 2, TipoProductoId = 1, Nombre = "Tubo epoxi", Detalle = "Tubo epoxi 1 pulgada de gas x 2 x 12m", Precio = 9800 });
    productosIniciales.Add(new Producto() { IdProducto = 3, TipoProductoId = 2, Nombre = "Hierro del 8", Detalle = "Hierro Acindar corrugado de 8X12m ", Precio = 1200 });
    productosIniciales.Add(new Producto() { IdProducto = 4, TipoProductoId = 2, Nombre = "Hierro del 12", Detalle = "Hierro Acindar corrugado de 12x12m", Precio = 3000 });
    productosIniciales.Add(new Producto() { IdProducto = 5, TipoProductoId = 3, Nombre = "Bronce", Detalle = "Metal en bruto, barras de 20kg", Precio = 50000 });
    productosIniciales.Add(new Producto() { IdProducto = 6, TipoProductoId = 3, Nombre = "Plomo", Detalle = "Metal en bruto, barra de 20kg", Precio = 10500 });
    productosIniciales.Add(new Producto() { IdProducto = 7, TipoProductoId = 4, Nombre = "Perfil c", Detalle = "Perfil de aluminio para averturas x6m", Precio = 15000 });
    productosIniciales.Add(new Producto() { IdProducto = 8, TipoProductoId = 4, Nombre = "Perfil cuadrado", Detalle = "Perfil de aluminio para averturas 20X40x6m", Precio = 30000 });
    productosIniciales.Add(new Producto() { IdProducto = 9, TipoProductoId = 5, Nombre = "Perfil I", Detalle = "Perfil IPN I tipo viga x 12m", Precio = 690000 });
    productosIniciales.Add(new Producto() { IdProducto = 10, TipoProductoId = 5, Nombre = "Perfil T", Detalle = "Perfil IPN T x 12m", Precio = 590000 });
    productosIniciales.Add(new Producto() { IdProducto = 11, TipoProductoId = 6, Nombre = "Chapa Acanalada", Detalle = "Chapas acanalada 1,1x12m", Precio = 20000 });
    productosIniciales.Add(new Producto() { IdProducto = 12, TipoProductoId = 6, Nombre = "Chapa rombo pintada", Detalle = "Chapa rombo pintada 1,2x12m premium ", Precio = 28000 });

    modelBuilder.Entity<Producto>(producto =>
      {
        producto.ToTable("Producto");
        producto.HasKey(p => p.IdProducto);
        producto.HasOne(p => p.TipoProducto).WithMany(p => p.Productos).HasForeignKey(p => p.TipoProductoId);
        producto.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
        producto.Property(s => s.Detalle).HasMaxLength(200);
        producto.Property(p => p.Precio).IsRequired();
        producto.HasData(productosIniciales);

      });
    List<Stock> stockInicial = new List<Stock>();
    stockInicial.Add(new Stock() { IdStock = 1, ProductoId = 1, Cantidad = 12 });
    stockInicial.Add(new Stock() { IdStock = 2, ProductoId = 2, Cantidad = 15 });
    stockInicial.Add(new Stock() { IdStock = 3, ProductoId = 3, Cantidad = 60 });
    stockInicial.Add(new Stock() { IdStock = 4, ProductoId = 4, Cantidad = 2 });
    stockInicial.Add(new Stock() { IdStock = 5, ProductoId = 5, Cantidad = 8 });
    stockInicial.Add(new Stock() { IdStock = 6, ProductoId = 6, Cantidad = 19 });
    stockInicial.Add(new Stock() { IdStock = 7, ProductoId = 7, Cantidad = 14 });
    stockInicial.Add(new Stock() { IdStock = 8, ProductoId = 8, Cantidad = 18 });
    stockInicial.Add(new Stock() { IdStock = 9, ProductoId = 9, Cantidad = 100 });
    stockInicial.Add(new Stock() { IdStock = 10, ProductoId = 10, Cantidad = 112 });
    stockInicial.Add(new Stock() { IdStock = 11, ProductoId = 11, Cantidad = 145 });
    stockInicial.Add(new Stock() { IdStock = 12, ProductoId = 12, Cantidad = 133 });
    modelBuilder.Entity<Stock>(stock =>
   {
     stock.ToTable("Stock");
     stock.HasKey(s => s.IdStock);
     stock.HasOne(s => s.Producto).WithMany(s => s.Stocks).HasForeignKey(s => s.ProductoId);
     stock.Property(s => s.Cantidad);
     stock.HasData(stockInicial);

   });
  }

}