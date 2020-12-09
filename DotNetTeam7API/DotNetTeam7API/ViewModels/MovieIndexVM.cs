using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetTeam7API.ViewModels
{
    public class MovieIndexVM
    {
        public List<MovieVM> Movies { get; set; }
        public List<SelectListItem> Genres { get; set; }
        public int? GenreFilterApplied { get; set; }
    }
}
