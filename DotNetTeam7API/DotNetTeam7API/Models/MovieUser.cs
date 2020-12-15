using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetTeam7API.Models
{
    public class MovieUser
    {
        [Key]
        public int MovieUserId { get; set; }

        [Required]//[Key, Column(Order = 1)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MovieId { get; private set; }

        [Required]
        public string UserId { get; private set; }

        public int Rating { get;  set; }
        public string Review { get; private set; }
        public bool? Fav { get; private set; }

        ////public virtual IdentityUser User { get; private set; }
        public virtual Movie Movie { get; private set; }

        public MovieUser (
            int movieId,
            string userId,
            int rating//, tQ: rest is yet to be implemented
            //string review,
            //bool fav
            )
        {
            MovieId = movieId;
            UserId = userId;
            Rating = rating;
            //string review,
            //bool fav
        }
    }
}
