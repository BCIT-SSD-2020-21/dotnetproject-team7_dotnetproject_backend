using DotNetTeam7API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetTeam7API.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        // tQ: every interface of this type will enforce the definition of the following functionality
        //     does not actually run query, can run filters on top of this; limits traffic to db and saves time
        IQueryable<T> GetAll();
    }
}
