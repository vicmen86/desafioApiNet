namespace ApiNet.Models;

public class Stock
{
  public int IdStock { get; set; }
  public int ProductoId { get; set; }
  public int Cantidad { get; set; }
  public virtual Producto Producto { get; set; }


}