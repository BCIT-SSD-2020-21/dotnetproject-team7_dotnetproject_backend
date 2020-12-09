using DotNetTeam7API.Interfaces;
using DotNetTeam7API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetTeam7API.Data
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly MovieDbContext _db;

        public BaseRepository(MovieDbContext db)
        {
            _db = db;
        }
    }
}
