using DotNetTeam7API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetTeam7API.Interfaces
{
    public interface IMovieService
    {
        Movie GetMovies(int? genreId);
    }
}
