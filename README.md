# Superhero API - Web API in C#
done: June 3-4, 2023

## Learned / Reflections:

### Repository Pattern
- The Controller should not contain any logic / business logic
  - should only contain the API endpoint concerns
- The Services - should contain the logic / business logic
  - the methods (ex. `GetAllData()`, `GetSingleDataById()`,`Add()`,`Update()`,`Delete()`)
- Repository Pattern - separates the concerns using "repositories" (directories)

### Dependency Injection

- THE _ thingy that is used for Dependency Injections
```csharp
  private readonly DataContext _context;

  public SuperheroService(DataContext context)
  {
    _context = context;
  }
```
- Dependencies are injected through contructors
```csharp
  // register ISuperheroService, and use SuperheroService (Dependency Injection)
  builder.Services.AddScoped<ISuperheroService, SuperheroService>();
  // register a database of shape DataContext
  builder.Services.AddDbContext<DataContext>();
```
  - *example 1:* 
    - the `SuperheroService` class above "depends" on the `DataContext`
class (uses the `DataContext` class) for accessing the database
  - *example 2:*
    - the `SuperheroController` uses the `ISuperheroService` 
    - this interface is used by `SuperheroService`,
    added in the `AddScoped<ISuperheroService, SuperheroService>` registry 
    - The AddScoped is need for Dependency Injection (DI) to work
      - also has AddTransient and AddSingleton

### EF Core setup
- Install Entity Framework Core via `.NET CLI`
```bash
 dotnet ef # check if entity framework is already installed
 dotnet tool install --global dotnet-ef
 dotnet ef # check installation complete
```

### EF migrations and connecting to SQL Server
- Migration and build for EF
```bash
 dotnet ef migrations add InitialCreate # <InitialCreate> can be any string like in git commit
 # dotnet ef migrations update <InitialCreate> - for update
 dotnet build
```
- Connecting to SQL Server with the Data Context and connection string
  - `cd` first to project directory
```bash
 dotnet ef database update
```

### Task generic, async await
- When using Task generics - the methods used should always be with "Async" keyword when in expensive computations
  - *example:* `Find()` becomes `FindAsync()`, `ToList()` becomes `ToListAsync()`

### CRUD Operations
- Create, Read, Update, Delete - yes the 4 pillars of every app in the universe
- returning with HTTP verbs in Controllers (very clean methods btw exquisite C#)

## Technologies Used:
- C# 11
- .NET 7
- Entity Framework Core
- SQL Server
- Swagger
- JetBrains Rider with IdeaVim - for IDE