using DotNetTeam7API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetTeam7API.Data
{
    public class OwenIsGoodMovieContext : DbContext
    {
        public OwenIsGoodMovieContext(DbContextOptions<OwenIsGoodMovieContext> options) : base(options) { }
        public DbSet<ToDo> ToDos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<MovieUser>().HasData(
                    new { MovieId = 1, UserId = "2", Rating = "1" },
                    new { MovieId = 2, UserId = "3", Rating = "5" },
                    new { MovieId = 3, UserId = "4", Rating = "3" }
                );
        }
    }
}