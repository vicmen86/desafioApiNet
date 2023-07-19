
using System.Text.Json.Serialization;

namespace ApiNet.Models;

public class Producto
{
  public int IdProducto { get; set; }
  public int TipoProductoId { get; set; }

  public string Nombre { get; set; }
  public string Detalle { get; set; }
  public int Precio { get; set; }
  public virtual TipoProducto TipoProducto { get; set; }
  [JsonIgnore]
  public virtual ICollection<Stock> Stocks { get; set; }
}