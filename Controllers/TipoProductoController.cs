using ApiNet.Models;
using ApiNet.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiNet.Controllers;

[ApiController]
[Route("[controller]")]
public class TipoProductoController: ControllerBase
{
    ITipoProductoService TipoProductoService;

    public TipoProductoController(ITipoProductoService service)
    {
        TipoProductoService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(TipoProductoService.Get());
    }


    [HttpPost]
    public IActionResult Post([FromBody] TipoProducto tipoProducto)
    {
        TipoProductoService.Save(tipoProducto);
        return Ok();
    }


    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] TipoProducto tipoProducto)
    {
        TipoProductoService.Update(id, tipoProducto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        TipoProductoService.Delete(id);
        return Ok();
    }    
}