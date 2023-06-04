namespace SuperheroAPI.Service.SuperheroService;

public interface ISuperheroService
{
    Task<List<Superhero>> GetAllHeroes();
    Task<Superhero?> GetSingleHero(int id);

    Task<List<Superhero>?> AddHero(Superhero superhero);
    Task<List<Superhero>?> UpdateHero(int id, Superhero request);

    Task<List<Superhero>?> DeleteHero(int id);
}