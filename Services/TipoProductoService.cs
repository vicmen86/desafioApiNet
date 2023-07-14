using ApiNet.Models;

namespace ApiNet.Services;

public class TipoProductoService : ITipoProductoService
{
  ProductsContext context;
  public TipoProductoService(ProductsContext dbcontext)
  {
    context = dbcontext;
  }
  public IEnumerable<TipoProducto> Get()
  {
    return context.TipoProductos;
  }
  public async Task Save(TipoProducto tipoProducto)
  {
    context.Add(tipoProducto);
    await context.SaveChangesAsync();
  }
  public async Task Update(int id, TipoProducto tipoProducto)
  {
    var tipoProductoActual = context.TipoProductos.Find(id);

    if (tipoProductoActual != null)
    {
      tipoProductoActual.Descripcion = tipoProducto.Descripcion;
      
      await context.SaveChangesAsync();
    }
  }
  public async Task Delete(int id)
  {
    var tipoProductoActual = context.TipoProductos.Find(id);

    if (tipoProductoActual != null)
    {
      context.Remove(tipoProductoActual);
      await context.SaveChangesAsync();
    }
  }
}
//Todos los metos que queremos exponer
public interface ITipoProductoService
{
  IEnumerable<TipoProducto> Get();
  Task Save(TipoProducto tipoProducto);

  Task Update(int id, TipoProducto tipoProducto);

  Task Delete(int id);
}