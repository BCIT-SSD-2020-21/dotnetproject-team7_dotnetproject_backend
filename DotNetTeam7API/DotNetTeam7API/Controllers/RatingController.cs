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
    [Route("ratings/[controller]")]
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
        public string GetAvgByMovieId(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
