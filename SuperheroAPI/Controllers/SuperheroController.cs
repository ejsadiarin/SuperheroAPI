using Microsoft.AspNetCore.Mvc;
using SuperheroAPI.Model;

namespace SuperheroAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SuperheroController : ControllerBase
{
    // GET
    [HttpGet]
    public async Task<IActionResult> GetAllHeroes()
    {
        var superheroes = new List<Superhero>
        {
            new Superhero
            {
                Id = 1,
                Name = "Spider Man",
                FirstName = "Peter",
                LastName = "Parker",
                Place = "New York City"
            }
        };
        
        return Ok(superheroes);
    }
}