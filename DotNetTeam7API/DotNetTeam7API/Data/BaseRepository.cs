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

        // tQ: upon startup, because of dependency injection, dbContext referred to in StartUp is instantiated
        public BaseRepository(MovieDbContext db)
        {
            _db = db;
        }
        public IQueryable<T> GetAll()
        {
            // tQ: need to return return data set of type T
            return _db.Set<T>();
        }

        public IQueryable<T> GetAllByGenre(int genreId)
        {
            return _db.Movies
                .Include(m => m.MovieGenre)
                .ThenInclude(mg => mg.Movie)
                .Where(m => m.Id = mg.MovieId)
                .FirstOrDefault();
        }
    }
}
