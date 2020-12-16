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

            db.Database.ExecuteSqlRaw("DELETE FROM [MovieGenres]");
            db.Database.ExecuteSqlRaw("DELETE FROM [MovieUsers]");
            db.Database.ExecuteSqlRaw("DELETE FROM [Genres]");
            db.Database.ExecuteSqlRaw("DELETE FROM [Movies]");

            await db.SaveChangesAsync();

            if (!await db.Genres.AnyAsync())
            {
                // tQ: add range of movie genres
                await db.Genres.AddRangeAsync(GetPreconfiguredGenres());
                await db.SaveChangesAsync();
            }
            
            if (!await db.Movies.AnyAsync())
            {
                // tQ: add range of movies
                if (MovieDbSeedConverter.Movies.Count == 0)
                {
                    await MovieDbSeedConverter.Convert();
                }

                await db.Movies.AddRangeAsync(MovieDbSeedConverter.Movies);
                await db.SaveChangesAsync();
            }

            if (!await db.MovieGenres.AnyAsync())
            {
                // tQ: add range of movie genres
                if (MovieDbSeedConverter.MovieGenres.Count == 0)
                {
                    await MovieDbSeedConverter.Convert();
                }

                await db.MovieGenres.AddRangeAsync(MovieDbSeedConverter.MovieGenres);
                await db.SaveChangesAsync();
            }
        }

        static IEnumerable<Genre> GetPreconfiguredGenres()
        {
            return new List<Genre>()
            {
                new Genre(28,"Action"),
                new Genre(12,"Adventure"),
                new Genre(14,"Fantasy"),
                new Genre(36,"History"),
                new Genre(27,"Horror"),
                new Genre(10402,"Music"),
                new Genre(9648,"Mystery"),
                new Genre(10749,"Romance"),
                new Genre(878,"Science Fiction"),
                new Genre(10770,"TV Movie"),
                new Genre(53,"Thriller"),
                new Genre(10752,"War"),
                new Genre(37,"Western"),
                new Genre(10759,"Action & Adventure"),
                new Genre(16,"Animation"),
                new Genre(35,"Comedy"),
                new Genre(80,"Crime"),
                new Genre(99,"Documentary"),
                new Genre(18,"Drama"),
                new Genre(10751,"Family"),
                new Genre(10762,"Kids"),
                new Genre(10763,"News"),
                new Genre(10764,"Reality"),
                new Genre(10765,"Sci-Fi & Fantasy"),
                new Genre(10766,"Soap"),
                new Genre(10767,"Talk"),
                new Genre(10768,"War & Politics")
            };
        }
    }
}
