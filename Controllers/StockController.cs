using ApiNet.Models;
using ApiNet.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiNet.Controllers;

[ApiController]
[Route("[controller]")]
public class StoxkController: ControllerBase
{
    IStockService stockService;

    public StoxkController(IStockService service)
    {
        stockService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(stockService.Get());
    }


    [HttpPost]
    public IActionResult Post([FromBody] Stock stock)
    {
        stockService.Save(stock);
        return Ok();
    }


    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Stock stock)
    {
        stockService.Update(id, stock);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        stockService.Delete(id);
        return Ok();
    }    
}