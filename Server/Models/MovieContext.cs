using BlazorCRUD.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUD.Server.Models{
public class MovieContext : DbContext
{
    #region Contructor
    public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
    {

    }
    #endregion

    #region Public properties
    public DbSet<Movie> Movies { get; set; }
    #endregion

    #region Overidden methods
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>().HasData(GetMovies());
        base.OnModelCreating(modelBuilder);
    }
    #endregion


    #region Private methods
    private List<Movie> GetMovies()
    {
        return new List<Movie>
    {
        new Movie
        {
            ID = 1,
            Title = "When Harry Met Sally",
            ReleaseDate = DateTime.Parse("1989-2-12"),
            Genre = "Romantic Comedy",
            Price = 7.99M
        },

        new Movie
        {
            ID = 2,
            Title = "Ghostbusters ",
            ReleaseDate = DateTime.Parse("1984-3-13"),
            Genre = "Comedy",
            Price = 8.99M
        },

        new Movie
        {
            ID = 3,
            Title = "Ghostbusters 2",
            ReleaseDate = DateTime.Parse("1986-2-23"),
            Genre = "Comedy",
            Price = 9.99M
        },

        new Movie
        {
            ID = 4,
            Title = "Rio Bravo",
            ReleaseDate = DateTime.Parse("1959-4-15"),
            Genre = "Western",
            Price = 3.99M
        }
    };
    }
    #endregion
}
}