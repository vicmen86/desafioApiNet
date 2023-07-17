using ApiNet.Models;

namespace ApiNet.Services;

public class StockService : IStockService
{
  ProductsContext context;
  public StockService(ProductsContext dbcontext)
  {
    context = dbcontext;
  }
  public IEnumerable<Stock> Get()
  {
    return context.Stocks;
  }
  public async Task Save(Stock stock)
  {
    context.Add(stock);
    await context.SaveChangesAsync();
  }
  public async Task Update(int id, Stock stock)
  {
    var stockActual = context.Stocks.Find(id);

    if (stockActual != null)
    {
      stock.Cantidad = stock.Cantidad;

      await context.SaveChangesAsync();
    }
  }
  public async Task Delete(int id)
  {
    var stockActual = context.Stocks.Find(id);

    if (stockActual != null)
    {
      context.Remove(stockActual);
      await context.SaveChangesAsync();
    }
  }
}
//Todos los metos que queremos exponer
public interface IStockService
{
  IEnumerable<Stock> Get();
  Task Save(Stock stock);

  Task Update(int id, Stock stock);

  Task Delete(int id);
}