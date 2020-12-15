using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetTeam7API.Data;
using DotNetTeam7API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNetTeam7API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly MovieDbContext _db;

        public RatingController(MovieDbContext db)
        {
            _db = db;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_db.MovieUsers.ToList());
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IActionResult GetAvgByMovieId(int id)
        {
            var records = _db.MovieUsers
                .Select(mu => mu)
                .Where(m => m.MovieId == id).ToList();
            if (records.Count > 0)
            {
                var avg = records.Select(mu => mu).Average(mu => mu.Rating);
                return Ok(avg.ToString());
            }
            else
            {
                return BadRequest("Movie not found in ratings table");
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Create([FromBody] MovieUser movieUser)
        {
            if (movieUser.UserId == null 
                || movieUser.UserId == "")
            {
                return BadRequest();
            }
            _db.MovieUsers.Add(movieUser);
            // tQ: to do - update rating field in Movie table
            _db.SaveChanges();
            return new ObjectResult(movieUser);
        }
    }
}
