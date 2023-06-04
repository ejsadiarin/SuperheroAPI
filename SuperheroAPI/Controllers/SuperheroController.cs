using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using SuperheroAPI.Service.SuperheroService;

namespace SuperheroAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SuperheroController : ControllerBase
{
    private readonly ISuperheroService _superheroService;

    public SuperheroController(ISuperheroService superheroService)
    {
        // Dependency Injection
        _superheroService = superheroService;
    }

    // GET
    [HttpGet]
    // public async Task<IActionResult> GetAllHeroes()
    public async Task<ActionResult<List<Superhero>>> GetAllHeroes()
    {
        var result = await _superheroService.GetAllHeroes();
        return Ok(result);
        
        // can just be: return await _superheroService.GetALlHeroes();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Superhero>> GetSingleHero(int id)
    {
        var result = _superheroService.GetSingleHero(id);
        if (result is null)
        {
            return NotFound("Superhero doesn't exist.");
        }

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<List<Superhero>>> AddHero(Superhero superhero)
    {
        var result = _superheroService.AddHero(superhero);

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<List<Superhero>>> UpdateHero(int id, Superhero request)
    {
        var result = _superheroService.UpdateHero(id, request);
        if (result is null)
        {
            return NotFound("Superhero ID not found.");
        }
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Superhero>>> DeleteHero(int id)
    {
        var result = _superheroService.DeleteHero(id);
        if (result is null)
        {
            return NotFound("Superhero ID not found.");
        }
        return Ok(result);
    }
}