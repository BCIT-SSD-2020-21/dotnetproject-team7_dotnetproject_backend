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
        private readonly IBaseRepository<MovieUser> _movieUserRepo;

        public MovieService(IBaseRepository<Movie> movieRepo,
            IBaseRepository<Genre> genreRepo,
            IBaseRepository<MovieUser> movieUserRepo)
        {
            _movieRepo = movieRepo;
            _genreRepo = genreRepo;
            _movieUserRepo = movieUserRepo;
        }
        public List<MovieVM> GetMovies(int? genreId, string searchTerm)
        {
            var movies = _movieRepo.GetAll();
            //var genres = _genreRepo.GetAll(); 

            var ret = new List<Movie>();
            if (searchTerm != null)
            {
                if (genreId != null)
                {
                    ret.AddRange(
                        movies.Include(m => m.MovieGenres)
                        .Where(m => m.MovieGenres.Any(mg => mg.GenreId == genreId)
                        && (m.Name.Contains(searchTerm) || m.Overview.Contains(searchTerm))));
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

            var ret_vm = new List<MovieVM>();
            if (ret.Count() > 0)
                ret.ForEach(m => ret_vm.Add(MapToMovieVM(m)));

            return ret_vm;
        }

        public MovieVM GetById(int movieId)
        {
            var movie_ret = _movieRepo
                .GetAll()
                .Include(m => m.MovieGenres)
                .ThenInclude(mg => mg.Genre)
                .Where(m => m.Id == movieId)
                .FirstOrDefault();

            return MapToMovieVM(movie_ret);
        }

        private MovieVM MapToMovieVM(Movie movie)
        {
            return new MovieVM
            {
                MovieId = movie.Id,
                Backdrop_path = movie.Backdrop_path,
                First_air_date = movie.First_air_date,
                Name = movie.Name,
                Overview = movie.Overview,
                Poster_path = movie.Poster_path,
                // tQ: max rating for TMDB is 10, ours is 5, hence dividing by 2
                TMDB_average = movie.Vote_average / 2,
                Korflix_average = GetAvgRating(movie)
               };
        }

        private double GetAvgRating(Movie movie)
        {
            var movies = _movieUserRepo.GetAll()
                .Where(mu => mu.MovieId == movie.Id)
                .Select(mu => mu.Rating)
                .ToList();

            if (movies.Count() > 0)
            {     
                return Math.Round(movies.Average(), 1);
            } 
            else
            {
                return 0;
            }
        }
    }
}
