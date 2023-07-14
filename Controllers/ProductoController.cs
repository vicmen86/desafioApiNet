using ApiNet.Models;
using ApiNet.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiNet.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductoController: ControllerBase
{
    IProductoService productoService;

    public ProductoController(IProductoService service)
    {
        productoService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(productoService.Get());
    }


    [HttpPost]
    public IActionResult Post([FromBody] Producto producto)
    {
        productoService.Save(producto);
        return Ok();
    }


    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Producto producto)
    {
        productoService.Update(id, producto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        productoService.Delete(id);
        return Ok();
    }    
}