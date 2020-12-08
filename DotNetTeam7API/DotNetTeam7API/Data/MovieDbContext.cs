using DotNetTeam7API.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetTeam7API.Data
{

    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options) { }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieGenre>()
                .HasKey(cp => new { cp.MovieId, cp.GenreId });

            modelBuilder.Entity<MovieGenre>()
                .HasOne(cp => cp.Movie)
                .WithMany(cp => cp.MovieGenre)
                .HasForeignKey(fk => new { fk.MovieId });

            modelBuilder.Entity<MovieGenre>()
                    .HasOne(cp => cp.Genre)
                    .WithMany(cp => cp.MovieGenre)
                    .HasForeignKey(fk => new { fk.GenreId });

            modelBuilder.Entity<Movie>().HasData(
                new
                {
                    backdrop_path = "/mXouvrZbn8YpZMURGvw30QK8qfo.jpg",
                    first_air_date = "2019-08-22",
                    id = 89641,
                    name = "Love Alarm",
                    original_language = "ko",
                    original_name = "좋아하면 울리는",
                    overview = "Love Alarm is an app that tells you if someone within a 10-meter radius has a crush on you. It quickly becomes a social phenomenon. While everyone talks about it and uses it to test their love and popularity, Jojo is one of the few people who have yet to download the app. However, she soon faces a love triangle situation between Sun-oh whom she starts to have feelings for, and Hye-young, who has had a huge crush on her.",
                    popularity = 166.605,
                    poster_path = "/s87JyAWtRLLlmsYWXTED1l8henB.jpg",
                    vote_average = 8.4,
                    vote_count = 577
                });

            modelBuilder.Entity<MovieGenre>().HasData(
    new { MovieId = 89641, GenreId = 18 },
    new { MovieId = 89641, GenreId = 10765 });


            modelBuilder.Entity<Genre>().HasData(
                new { Id = 18, Name = "Drama" },
                new { Id = 10765, Name = "Annimation" });
        }



    }
}
