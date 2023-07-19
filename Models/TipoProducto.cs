using System.Text.Json.Serialization;

namespace ApiNet.Models;

public class TipoProducto{
public int IdTipoProducto { get; set; }
public string Descripcion { get; set; }
[JsonIgnore]
public virtual ICollection<Producto> Productos { get; set; }
}