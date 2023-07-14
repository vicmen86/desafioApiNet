namespace ApiNet.Models;

public class TipoProducto{
public int IdTipoProducto { get; set; }
public string Descripcion { get; set; }
public virtual ICollection<Producto> Productos { get; set; }
}