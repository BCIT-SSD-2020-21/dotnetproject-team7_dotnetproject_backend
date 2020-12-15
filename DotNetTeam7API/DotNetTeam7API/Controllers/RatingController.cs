using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetTeam7API.Data;
using DotNetTeam7API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNetTeam7API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly MovieDbContext _db;
        private readonly AuthContext _auDb;

        public RatingController(MovieDbContext db, AuthContext auDb)
        {
            _db = db;
            _auDb = auDb;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_db.MovieUsers.ToList());
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string GetAvgByMovieId(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Create([FromBody] MovieUser movieUser)
        {
            // check null
            if (movieUser == null || String.IsNullOrEmpty(movieUser.UserId))
            {
                return BadRequest();
            }

            // check null
            if (!(new List<int> { 1, 2, 3, 4, 5 }).Contains(movieUser.Rating) )
            {
                return BadRequest();
            }

            // validate movie id
            var movie = _db.Movies.Where(m => m.Id == movieUser.MovieId).FirstOrDefault();
            if (movie == null)
            {
                return BadRequest();
            }

            // validate use id
            var user = _auDb.Users
                                .Where(a => a.Id == movieUser.UserId)
                                .FirstOrDefault();
            if (movie == null)
            {
                return BadRequest();
            }

            var movieuser = _db.MovieUsers
                          .Where(mu => mu.MovieId == movieUser.MovieId && mu.UserId == movieUser.UserId)
                                .FirstOrDefault();

            if (movieuser == null)
            {
                // add movie-user
                _db.MovieUsers.Add(movieUser);               
            }
            else 
            {
                // update movie-user
                movieuser.Rating = movieUser.Rating;
            }

            _db.SaveChanges();

            return Ok(movieUser);

        }
    }
}
