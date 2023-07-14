namespace apiNet.Models;

public class Stock
{
  public Guid IdStock { get; set; }
  public Guid ProductoId { get; set; }
  public string Descripcion { get; set; }
  public int Cantidad { get; set; }
  public virtual Producto Producto { get; set; }


}