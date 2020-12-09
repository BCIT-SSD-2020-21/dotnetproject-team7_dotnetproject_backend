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

        public int Id { get; set; }

        public string Name { get; set; }

        public string Original_language { get; set; }

        public string Original_name { get; set; }

        public string Overview { get; set; }

        public double Popularity { get; set; }

        public string Poster_path { get; set; }

        public double Vote_average { get; set; }

        public int Vote_count { get; set; }
    }
}
