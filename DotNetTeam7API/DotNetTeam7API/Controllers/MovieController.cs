using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetTeam7API.Data;
using DotNetTeam7API.Models;
using DotNetTeam7API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetTeam7API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {

        public MovieIndexVM MovieIndex = new MovieIndexVM();

        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetAll()
        {
            try
            {
                MovieIndex = new MovieIndexVM() {
                    _db.Movies.Include(m => m.MovieGenres)
                   .ThenInclude(g => g.Genre)
                    .ToList()
                };

                //  JMT ( 2020-12-09) remove the redundant nested movies and genres to avoid crash browser, which only allows 32 nested layers
                foreach (var m in MovieIndex)
                { 
                    foreach ( var mg in m.MovieGenres)
                    {
                        mg.Genre.MovieGenres.Clear();
                        mg.Movie = null; 
                    }
                }

                if (!MovieIndex.Any())
                    return NoContent();

                return Ok(MovieIndex);

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
                MovieIndexVM = new MovieIndexVM()
                {   _db.Movies.Include(m => m.MovieGenres)
                    .ThenInclude(g => g.Genre)
                    .Where(m => m.Id == id)
                    .FirstOrDefault();
                }

                if (MovieIndexVM == null)
                    return NoContent();

                return Ok(MovieIndexVM);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
