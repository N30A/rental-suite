using Microsoft.AspNetCore.Mvc;

namespace N30A.Suite.Web.Controllers;

[Route("kunder")]
public class CustomerController : BaseController
{   
    [HttpGet("privatpersoner")]
    public IActionResult Individuals()
    {
        return View();
    }
    
    [HttpGet("foretag")]
    public IActionResult Companies()
    {
        return View();
    }
}
