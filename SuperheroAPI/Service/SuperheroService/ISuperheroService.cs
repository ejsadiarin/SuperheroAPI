namespace SuperheroAPI.Service.SuperheroService;

public interface ISuperheroService
{
    List<Superhero> GetAllHeroes();
    Superhero? GetSingleHero(int id);

    List<Superhero>? AddHero(Superhero superhero);
    List<Superhero>? UpdateHero(int id, Superhero request);

    List<Superhero>? DeleteHero(int id);
}