using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetTeam7API.Models
{
    public class Genre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; private set; }
        public string Name { get; private set; }

        // navigation properties
        public virtual ICollection<MovieGenre> MovieGenre { get; private set; }

        public Genre(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
