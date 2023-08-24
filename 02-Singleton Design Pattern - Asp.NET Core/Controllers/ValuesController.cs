using _02_Singleton_Design_Pattern___Asp.NET_Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _02_Singleton_Design_Pattern___Asp.NET_Core.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    [HttpGet("x")]
    public IActionResult X()
    {
        var dataBase = DataBaseService.Instance;
        dataBase.Connection();
        dataBase.DisConnection();
        return Ok(dataBase.Count);
    }
    [HttpGet("y")]
    public IActionResult Y()
    {
        var dataBase = DataBaseService.Instance;
        dataBase.Connection();
        dataBase.DisConnection();
        return Ok(dataBase.Count);
    }
}
