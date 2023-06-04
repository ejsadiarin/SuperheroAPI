using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using SuperheroAPI.Model;

namespace SuperheroAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SuperheroController : ControllerBase
{
    private static List<Superhero> superheroes = new List<Superhero>
    {
        new Superhero
        {
            Id = 1,
            Name = "Spider Man",
            FirstName = "Peter",
            LastName = "Parker",
            Place = "New York City"
        },
        new Superhero
        {
            Id = 2,
            Name = "Iron Man",
            FirstName = "Tony",
            LastName = "Stark",
            Place = "Malibu"
        },
    };
    
    // GET
    [HttpGet]
    // public async Task<IActionResult> GetAllHeroes()
    public async Task<ActionResult<List<Superhero>>> GetAllHeroes()
    {
        return Ok(superheroes);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Superhero>> GetSingleHero(int id)
    {
        var hero = superheroes.Find(superhero => superhero.Id == id);
        if (hero is null)
        {
            return NotFound("This superhero doesn't exist.");
        }
        return Ok(hero);
    }

    [HttpPost]
    public async Task<ActionResult<List<Superhero>>> AddHero(Superhero superhero)
    {
        superheroes.Add(superhero);
        return Ok(superheroes);
    }

    [HttpPut]
    public async Task<ActionResult<List<Superhero>>> UpdateHero(int id, Superhero request)
    {
        var hero = superheroes.Find(superhero => superhero.Id == id);
        if (hero is null)
        {
            return NotFound("Hero ID specified doesn't exist to update");
        }

        hero.Name = request.Name;
        hero.FirstName = request.FirstName;
        hero.LastName = request.LastName;
        hero.Place = request.Place;
        
        return Ok(hero);
    }
    
    [HttpDelete]
    public async Task<ActionResult<List<Superhero>>> DeleteHero(int id)
     {
         // Find specific superhero in superheroes List
         var hero = superheroes.Find(superhero => superhero.Id == id);
         if (hero is null)
         {
             return NotFound("Hero ID specified doesn't exist to update");
         }

         superheroes.Remove(hero);
         
         return Ok(superheroes);
     }
}