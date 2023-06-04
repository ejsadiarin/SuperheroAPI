using SuperheroAPI.Model;

namespace SuperheroAPI.Service.SuperheroService;

public class SuperheroService : ISuperheroService
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

    public List<Superhero> GetAllHeroes()
    {
        return superheroes;
    }

    public Superhero? GetSingleHero(int id)
    {
        var hero = superheroes.Find(superhero => superhero.Id == id);
        if (hero is null)
        {
            return null;
        }

        return hero;
    }

    public List<Superhero> AddHero(Superhero superhero)
    {
        superheroes.Add(superhero);
        return superheroes;
    }

    public List<Superhero>? DeleteHero(int id)
    {
        // Find specific superhero in superheroes List
        var hero = superheroes.Find(superhero => superhero.Id == id);
        if (hero is null)
        {
            return null;
        }

        superheroes.Remove(hero);

        return superheroes;
    }

    public List<Superhero>? UpdateHero(int id, Superhero request)
    {
        var hero = superheroes.Find(superhero => superhero.Id == id);
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

        return superheroes;
    }
}