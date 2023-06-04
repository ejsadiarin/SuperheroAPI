global using Microsoft.EntityFrameworkCore;

namespace SuperheroAPI.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=superherodb;Trusted_Connection=True;TrustServerCertificate=True;");
    }
    
    public DbSet<Superhero> Superheros { get; set; }
}