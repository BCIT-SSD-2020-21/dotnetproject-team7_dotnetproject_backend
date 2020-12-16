using DotNetTeam7API.Interfaces;
using DotNetTeam7API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DotNetTeam7API.Services
{
    public class MovieService : IMovieService
    {
        private readonly IBaseRepository<Movie> _movieRepo;
        private readonly IBaseRepository<Genre> _genreRepo;

        public MovieService(IBaseRepository<Movie> movieRepo,
            IBaseRepository<Genre> genreRepo)
        {
            _movieRepo = movieRepo;
            _genreRepo = genreRepo;
        }
        // this is for get all it can split to create any number of collections
        // MovieIndexVM has List<MovieVm> and List<MovieDetailVm> and List<Genre>
        // simple implementation is List<MovieVM>
        // more complex is one beefy MovieIndexVM
        public List<BaseEntity> GetMovies(int? genreId, string searchTerm)
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

        public Movie GetById(int movieId)
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
    }
}
