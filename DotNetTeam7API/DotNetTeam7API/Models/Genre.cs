using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DotNetTeam7API.Models
{
    public class Genre : BaseEntity
    {
        public string Name { get; private set; }

        // navigation properties
        [JsonIgnore]
        public virtual ICollection<MovieGenre> MovieGenres { get; private set; }

        public Genre(int id, string name)
        {
            Name = name;
        }
    }
}
