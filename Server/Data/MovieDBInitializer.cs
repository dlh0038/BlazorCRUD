using BlazorCRUD.Shared.Models;
using BlazorCRUD.Server.Models;
using System;
using System.Linq;

namespace BlazorCRUD.Server.Data
{
    public static class MovieDBInitializer
    {
        public static void Initialize(ApplicationDBContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Movies.Any())
            {
                return;   // DB has been seeded
            }
            List<Movie> movies = new List<Movie>
            {
                new Movie
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    Price = 7.99M
                },

                new Movie
                {
                    Title = "Ghostbusters ",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Comedy",
                    Price = 8.99M
                },

                new Movie
                {
                    Title = "Ghostbusters 2",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Comedy",
                    Price = 9.99M
                },

                new Movie
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Western",
                    Price = 3.99M
                },
                new Movie
                {
                    Title = "Pulp Fiction",
                    ReleaseDate = DateTime.Parse("1994-10-14"),
                    Genre = "Action",
                    Price = 11.99M
                }
            };
            
            foreach (Movie movie in movies)
            {
                context.Movies.Add(movie);
            }
            context.SaveChanges();
        }
    }
}