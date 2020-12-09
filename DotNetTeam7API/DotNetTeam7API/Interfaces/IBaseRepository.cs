using DotNetTeam7API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetTeam7API.Interfaces
{
    public class IBaseRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
    }
}
