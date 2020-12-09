using DotNetTeam7API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetTeam7API.Interfaces
{
    interface IMovieVMService
    {
        MovieIndexVM GetMoviesVM(int? typeId);
        //IEnumerable<SelectListItem> GetTypes();
    }
}
