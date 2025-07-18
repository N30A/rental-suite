using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using N30A.Suite.Web.Models;

namespace N30A.Suite.Web.Controllers;

public class HomeController : BaseController
{
    public IActionResult Index()
    {
        return View();
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
