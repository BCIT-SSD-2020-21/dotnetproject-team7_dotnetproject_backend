using DotNetTeam7API.Models;
using DotNetTeam7API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetTeam7API.Interfaces
{
    public interface IMovieService
    {
        List<MovieVM> GetMovies(int? genreId, string searchTerm);
        MovieVM GetById(int movieId);
    }
}
