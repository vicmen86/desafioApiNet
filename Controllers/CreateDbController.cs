
using Microsoft.AspNetCore.Mvc;

namespace ApiNet.Controllers;

[ApiController]
[Route("createdb")]

public class CreateDbController : ControllerBase
{
  ProductsContext dbcontext;
  public CreateDbController(ProductsContext db){
    dbcontext = db;
  }
  [HttpGet]
  public IActionResult CreateDatabase()
  {
    dbcontext.Database.EnsureCreated();

    return Ok();
  }

}