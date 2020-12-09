﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetTeam7API.Models
{
    public class MovieGenre
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MovieId { get; private set; }
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GenreId { get; private set; }

        // navigation properties
        public virtual Movie Movie { get; set; }
        public virtual Genre Genre { get; set; }

        public MovieGenre(int movieId, int genreId)
        {
            MovieId = movieId;
            GenreId = genreId;
        }
    }
}
