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
                .WithMany(cp => cp.MovieGenres)
                .HasForeignKey(fk => new { fk.MovieId });

            modelBuilder.Entity<MovieGenre>()
                    .HasOne(cp => cp.Genre)
                    .WithMany(cp => cp.MovieGenres)
                    .HasForeignKey(fk => new { fk.GenreId });

            // tQ: MovieUser setup
            modelBuilder.Entity<MovieUser>()
                .HasKey(mu => new { mu.MovieId, mu.UserId });

            modelBuilder.Entity<MovieUser>()
                .HasOne(mu => mu.Movie)
                .WithMany(u => u.U)
                .HasForeignKey(fk => new { fk.MovieId });
        }
    }
}
