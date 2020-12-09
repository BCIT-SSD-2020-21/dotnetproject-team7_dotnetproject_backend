using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DotNetTeam7API.Models
{

    public class Movie
    {

        public string Backdrop_path { get; set; }

        public string First_air_date { get; set; }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Name { get; set; }


        public string Original_language { get; set; }

        public string Original_name { get; set; }

        public string Overview { get; set; }

        public double Popularity { get; set; }

        public string Poster_path { get; set; }

        public double Vote_average { get; set; }

        public int Vote_count { get; set; }

        // navigation properties
        [JsonIgnore]
        public virtual ICollection<MovieGenre> MovieGenres { get; private set; }

        // JMT ( 2020-12-09) : created a constructor, passed compile but failed on Add-Migration. Tried a few options, I have to 
        // follow the name convention we were not taught to use capital letter for property and camel case for passing parameter.
        // To avoid the super hassel, just discard the constructor as we might not use it.

        // tQ: adding new constructor after touching base with JMT
        public Movie (  string backdrop_path,
                        string first_air_date,
                        int id,
                        string name,
                        string original_language,
                        string original_name,
                        string overview,
                        double popularity,
                        string poster_path,
                        double vote_average,
                        int vote_count)
        {
            Backdrop_path = backdrop_path;
            First_air_date = first_air_date;
            Id = id;
            Name = name;
            Original_language = original_language;
            Original_name = original_name;
            Overview = overview;
            Popularity = popularity;
            Poster_path = poster_path;
            Vote_average = vote_average;
            Vote_count = vote_count;
        }
    }
}
