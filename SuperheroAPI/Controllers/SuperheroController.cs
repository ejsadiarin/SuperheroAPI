using Microsoft.AspNetCore.Mvc;

namespace SuperheroAPI.Controllers;

public class SuperheroController : ControllerBase
{
    // GET
    public IActionResult Index()
    {
        return View();
        
    }
}