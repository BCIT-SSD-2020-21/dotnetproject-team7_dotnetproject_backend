using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetTeam7API.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetTeam7API.Data
{
    public class MovieDbSeeder
    {
        // tQ: return type for async is Task
        public static async Task SeedAsync(MovieDbContext db)
        {
            if (!await db.MovieGenres.AnyAsync())
            {
                // tQ: add range of all movies
            }
            if (!await db.Movies.AnyAsync())
            {
                // tQ: add range of all movies
            }
        }

        static IEnumerable<Movie> GetPreconfiguredItems()
        {
            return new List<Movie>()
        {

        };
        }

        static IEnumerable<Genre> GetPreconfiguredGenres()
        {
            return new List<Genre>()
            {
                new Genre(28, "Action"),
                new Genre(12, "Adventure"),
                new Genre(16, "Animation"),
                new Genre(35, "Comedy"),
                new Genre(80, "Crime"),
                new Genre(99, "Documentary"),
                new Genre(18, "Drama"),
                new Genre(10751, "Family"),
                new Genre(14, "Fantasy"),
                new Genre(36, "History"),
                new Genre(27, "Horror"),
                new Genre(10402, "Music"),
                new Genre(9648, "Mystery"),
                new Genre(10749, "Romance"),
                new Genre(878, "Science Fiction"),
                new Genre(10770, "TV Movie"),
                new Genre(53, "Thriller"),
                new Genre(10752, "War"),
                new Genre(37, "Western")
            };
        }
    }
}
