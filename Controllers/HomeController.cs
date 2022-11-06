using Microsoft.AspNetCore.Mvc;
using SignalRApi.Business;

namespace SignalRApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HomeController : ControllerBase
{
    readonly MyBusiness _myBusiness;

    public HomeController(MyBusiness myBusiness)
    {
        _myBusiness = myBusiness;
    }

    [HttpGet("{message}")]
    public async Task<IActionResult> Index(string message)
    {
        await _myBusiness.SendMessage(message);
        return Ok(new { success = "sent message"});
    }
}
