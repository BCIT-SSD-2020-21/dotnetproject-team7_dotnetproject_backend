using DotNetTeam7API.Interfaces;
using DotNetTeam7API.Models;
using DotNetTeam7API.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetTeam7API.Services
{
    public class MovieService : IMovieService
    {
        private readonly IBaseRepository<Movie> _movieRepo;
        private readonly IBaseRepository<Genre> _genreRepo;
        private readonly IQueryable<MovieUser> _movieUserRepo;

        public MovieService(IBaseRepository<Movie> movieRepo,
            IBaseRepository<Genre> genreRepo,
            IQueryable<MovieUser> movieUserRepo)
        {
            _movieRepo = movieRepo;
            _genreRepo = genreRepo;
            _movieUserRepo = movieUserRepo;
        }
        // this is for get all it can split to create any number of collections
        // MovieIndexVM has List<MovieVm> and List<MovieDetailVm> and List<Genre>
        // simple implementation is List<MovieVM>
        // more complex is one beefy MovieIndexVM
        public List<MovieVM> GetMovies(int? genreId, string searchTerm)
        {
            var movies = _movieRepo.GetAll();
            //var genres = _genreRepo.GetAll(); 

            var ret = new List<BaseEntity>();
            if (searchTerm != null)
            {
                if (genreId != null)
                {
                    ret.AddRange(
                        movies.Include(m => m.MovieGenres)
                        .Where(m => m.MovieGenres.Any(mg => mg.GenreId == genreId)
                        && (m.Name.Contains(searchTerm) || m.Overview.Contains(searchTerm))));

                    // map to VM here
                    // if 1000 then it averages ratings of 1000 movies...
                    // 2 movies then avg for movies 
                }
                else
                {
                    ret.AddRange(
                        movies.Where(m => (m.Name.Contains(searchTerm) || m.Overview.Contains(searchTerm))));
                }
            }
            else if (genreId != null)
            {
                ret.AddRange(
                    movies.Include(m => m.MovieGenres)
                    .Where(m => m.MovieGenres.Any(mg => mg.GenreId == genreId)));
            }
            else
            {
                ret.AddRange(movies);
                //ret.AddRange(genres);
            }
            return ret;
        }

        public MovieVM GetById(int movieId)
        {
            //.Include(m => m.MovieGenres)
            //        .ThenInclude(g => g.Genre)
            //        .Where(m => m.Id == id)
            //        .FirstOrDefault();
            var movie_ret = _movieRepo
                .GetAll()
                .Include(m => m.MovieGenres)
                .ThenInclude(mg => mg.Genre)
                .Where(m => m.Id == movieId)
                .FirstOrDefault();
            return movie_ret;
        }

        private List<MovieVM> MapToMovieVM(List<Movie> movies)
        {
            return movies.Select(m => new MovieVM
            {
                Backdrop_path = m.Backdrop_path,
                First_air_date = m.First_air_date,
                Name = m.Name,
                Overview = m.Overview,
                Poster_path = m.Poster_path,
                // tQ: max for TMDB is 10, ours is 5, hence dividing by 2
                TMDB_average = m.Vote_average / 2,
                Korflix_average = GetAvgRating(m)
        }).ToList();
        }

        private double GetAvgRating(Movie movie)
        {
            var avg = _movieUserRepo
                .Where(mu => mu.MovieId == movie.Id)
                .Select(mu => mu.Rating)
                .ToList().Average();
            return Math.Round(avg, 1);
        }
    }
}
