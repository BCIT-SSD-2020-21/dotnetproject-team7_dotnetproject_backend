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
    }
}
