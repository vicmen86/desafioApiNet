using ApiNet.Models;

namespace ApiNet.Services;

public class ProductoService : IProductoService
{
  ProductsContext context;
  public ProductoService(ProductsContext dbcontext)
  {
    context = dbcontext;
  }
  public IEnumerable<Producto> Get()
  {
    return context.Productos;
  }
  public async Task Save(Producto producto)
  {
    context.Add(producto);
    await context.SaveChangesAsync();
  }
  public async Task Update(int id, Producto producto)
  {
    var productoActual = context.Productos.Find(id);

    if (productoActual != null)
    {
      productoActual.Nombre = producto.Nombre;
      producto.Precio = producto.Precio;

      await context.SaveChangesAsync();
    }
  }
  public async Task Delete(int id)
  {
    var productoActual = context.Productos.Find(id);

    if (productoActual != null)
    {
      context.Remove(productoActual);
      await context.SaveChangesAsync();
    }
  }
}
//Todos los metos que queremos exponer
public interface IProductoService
{
  IEnumerable<Producto> Get();
  Task Save(Producto producto);

  Task Update(int id, Producto producto);

  Task Delete(int id);
}