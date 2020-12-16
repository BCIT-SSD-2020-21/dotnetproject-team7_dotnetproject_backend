using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetTeam7API.ViewModels
{
    public class MovieVM
    {

        public string Backdrop_path { get; set; }
        public string First_air_date { get; set; }
        public string Name { get; set; }
        public string Overview { get; set; }
        public string Poster_path { get; set; }
        public double TMDB_average { get; set; }
        public double Korflix_average { get; set; }
    }
}