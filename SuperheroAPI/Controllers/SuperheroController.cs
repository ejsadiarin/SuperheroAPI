using Microsoft.AspNetCore.Mvc;

namespace SuperheroAPI.Controllers;

public class SuperheroController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
        
    }
}