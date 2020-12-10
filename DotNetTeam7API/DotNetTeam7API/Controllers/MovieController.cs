﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetTeam7API.Data;
using DotNetTeam7API.Interfaces;
using DotNetTeam7API.Services;
using DotNetTeam7API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetTeam7API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        // tQ: now Index instantiates service
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // tQ: commenting out for debug purposes
        //private readonly MovieDbContext _db;

        //public MovieController(MovieDbContext db)
        //{
        //    _db = db;
        //}

        [HttpGet(Name = "GetAll")]
        public ActionResult GetAll(int? genreId)
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetAll(int? genreId, string? search)
        {
            try
            {
                var ret = _movieService.GetMovies(genreId);
                return Ok(ret);
                //if (genreId == null)
                //{
                //    // All Movies
                //    var movies = _db.Movies.ToList();
                //    var genres = _db.Genres.ToList();

                //    var ret = new { movies, genres };

                        return Ok(movies);
                    }
                    else 
                    {
                        // https://localhost:44367/movie?search=Jumong
                        // https://localhost:44367/movie?search=founder of the kingdom of Goguryeo
                        var movies = _db.Movies.Where(m => (m.Name.Contains(search) || m.Overview.Contains(search)));
                        return Ok(movies);
                    }
                }
                else if (genreId != null)
                {
                    // https://localhost:44367/movie?genreid=18 
                    var movies = _db.Movies.Include(m => m.MovieGenres)
                        .Where(m => m.MovieGenres.Any(mg => mg.GenreId == genreId));

                //    var ret = new { movies };

                //    return Ok(ret);
                //}


                    var ret = new { movies, genres };

                    return Ok(ret);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            try
            {
                // movie detail
                //var movie = _db.Movies.Include(m => m.MovieGenres)
                //    .ThenInclude(g => g.Genre)
                //    .Where(m => m.Id == id)
                //    .FirstOrDefault();

                var movie = _movieService.GetById(id);

                if (movie == null)
                    return NoContent();

                return Ok(movie);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}

