using DotNetTeam7API.Interfaces;
using DotNetTeam7API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetTeam7API.Services
{
    public class MovieVMService : IMovieVMService
    {
        private readonly IBaseRepository<Movie> _movieRepo;
        private readonly IBaseRepository<Genre> _genreRepo;

        public MovieVMService(IBaseRepository<Movie> movieRepo,
            IBaseRepository<Genre> genreRepo)
        {
            _movieRepo = movieRepo;
            _genreRepo = genreRepo;
        }

        public MovieIndexVM GetMoviesVM(int? genreId)
        {
            IQueryable<Movie> movies = _movieRepo.GetAll();
        }
    }
}
