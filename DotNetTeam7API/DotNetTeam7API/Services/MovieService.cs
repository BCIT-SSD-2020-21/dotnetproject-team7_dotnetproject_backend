using DotNetTeam7API.Interfaces;
using DotNetTeam7API.Models;
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

        public List<BaseEntity> GetMovies(int? genreId)
        {
            var movies = _movieRepo.GetAll();
            var genres = _genreRepo.GetAll();

            var ret = new List<BaseEntity>();
            if (genreId == null)
            {
                // All Movies
                ret.AddRange(movies.ToList());
                var genres_ret = genres.ToList();

                ret.AddRange(genres_ret);

            }
            else
            {
                // All Movies with genreid == genreId
                var movies_ret = movies
                    .Where(m => m.MovieGenres.Any(mg => mg.GenreId == genreId));

                ret.AddRange(movies_ret);

            }

            return ret;
        }

        public Movie GetById(int movieId)
        {
            //.Include(m => m.MovieGenres)
            //        .ThenInclude(g => g.Genre)
            //        .Where(m => m.Id == id)
            //        .FirstOrDefault();
            var movie_ret = _movieRepo.GetAll().Where(m => m.Id == movieId).FirstOrDefault();
            movie_ret.MovieGenres = 
            return movies_ret;
        }
    }
}
