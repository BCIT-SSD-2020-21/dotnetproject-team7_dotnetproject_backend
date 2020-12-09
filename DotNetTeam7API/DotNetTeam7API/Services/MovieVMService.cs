using DotNetTeam7API.Interfaces;
using DotNetTeam7API.Models;
using DotNetTeam7API.ViewModels;
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
            // tQ: default - select all movies
            IQueryable<Movie> movies = _movieRepo.GetAll();

            // tQ: add "WHERE" clause if typeId is given
            if (genreId != null)
                movies = movies.inclu
        }
    }
}
