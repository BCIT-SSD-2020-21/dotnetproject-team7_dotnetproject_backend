using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetTeam7API.Models
{

    public class Movie
    {

        public string backdrop_path { get; set; }

        public string first_air_date { get; set; }


        [Key]
        public int id { get; set; }

        public string name { get; set; }


        public string original_language { get; set; }

        public string original_name { get; set; }

        public string overview { get; set; }

        public double popularity { get; set; }

        public string poster_path { get; set; }

        public double vote_average { get; set; }

        public int vote_count { get; set; }

        // navigation properties
        public virtual ICollection<MovieGenre> MovieGenre { get; private set; }

        // JMT: created a constructor, passed compile but failed on Add-Migration. Tried a few options, I have to 
        // follow the name convention we were not taught to use capital letter for property and camel case for passing parameter.
        // To avoid the super hassel, just discard the constructor as we might not use it.
    }
}
