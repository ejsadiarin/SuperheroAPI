using SuperheroAPI.Data;
using SuperheroAPI.Model;

namespace SuperheroAPI.Service.SuperheroService;

public class SuperheroService : ISuperheroService
{
    private readonly DataContext _context;

    public SuperheroService(DataContext context)
    {
        _context = context;
    }

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

    public async Task<List<Superhero>> GetAllHeroes()
    {
        var heroes = await _context.Superheros.ToListAsync();
        return heroes;
    }

    public async Task<Superhero?> GetSingleHero(int id)
    {
        var hero = await _context.Superheros.FindAsync(id);
        if (hero is null)
        {
            return null;
        }

        return hero;
    }

    public async Task<List<Superhero>?> AddHero(Superhero superhero)
    {
        _context.Superheros.Add(superhero);
        // tell EF to save changes to database
        await _context.SaveChangesAsync();

        // Output all from database with new changes
        var heroes = await _context.Superheros.ToListAsync();
        return heroes;
    }

    public async Task<List<Superhero>?> DeleteHero(int id)
    {
        // Find specific superhero via ID in the Superheros database
        var hero = await _context.Superheros.FindAsync(id);
        if (hero is null)
        {
            return null;
        }

        _context.Superheros.Remove(hero);
        // tell EF to save changes to database
        await _context.SaveChangesAsync();

        // Output all from database with new changes
        var heroes = await _context.Superheros.ToListAsync();
        return heroes;
    }

    public async Task<List<Superhero>?> UpdateHero(int id, Superhero request)
    {
        var hero = await _context.Superheros.FindAsync(id);
        if (hero is null)
        {
            return null;
        }

        // TODO: make it so that you can update one field and retain other existing fields for the specific id
        // - feature: have option to mutate only one field, and retain existing data
        hero.Name = request.Name;
        hero.FirstName = request.FirstName;
        hero.LastName = request.LastName;
        hero.Place = request.Place;

        // tell EF to save changes to database
        await _context.SaveChangesAsync();

        // Output all from database with new changes
        var heroes = await _context.Superheros.ToListAsync();
        return heroes;
    }
}