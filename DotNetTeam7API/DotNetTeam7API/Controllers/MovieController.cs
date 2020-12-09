using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetTeam7API.Data;
using DotNetTeam7API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetTeam7API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieDbContext _db;

        public MovieController(MovieDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetAll()
        {
            try
            {
                var movies = _db.Movies.Include(m => m.MovieGenre)
                       .ThenInclude(g => g.Genre)
                       .ToList();

                if (!movies.Any())
                    return NoContent();

                return Ok(movies);
            }
            catch (Exception e)
            {
                return BadRequest();
            }

        }

        [HttpGet("{id}")]
        public ActionResult<Movie> GetById(int id)
        {
            try
            {
                var movie = _db.Movies.Include(m => m.MovieGenre)
                    .ThenInclude(g => g.Genre)
                    .Where(m => m.Id == id)
                    .FirstOrDefault();

                if (movie == null)
                    return NoContent();

                return Ok(movie);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
