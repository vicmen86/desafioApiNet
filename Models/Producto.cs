
namespace apiNet.Models;

public class Producto
{
  public Guid IdProducto { get; set; }
  public Guid TipoProductoId { get; set; }

  public string Nombre { get; set; }
  public int Precio { get; set; }
  public virtual TipoProducto TipoProducto { get; set; }
}