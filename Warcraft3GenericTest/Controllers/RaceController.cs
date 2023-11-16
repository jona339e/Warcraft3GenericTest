using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Warcraft3GenericTest.DTO;
using Warcraft3GenericTest.Interfaces;
using Warcraft3GenericTest.Models;
using Warcraft3GenericTest.Repositories;

namespace Warcraft3GenericTest.Controllers
{
    public class RaceController : GenericController<Race, RaceDTO>
    {

        public RaceController(IGenericRepository<Race> repository) : base(repository)
        {
        }

        // Override to specify includes for RaceController
        protected override Func<IQueryable<Race>, IIncludableQueryable<Race, object>>[] GetIncludes()
        {
            return new Func<IQueryable<Race>, IIncludableQueryable<Race, object>>[]
            {
                query => query.Include(u => u.Buildings),
                query => query.Include(u => u.Factions),
                query => query.Include(u => u.Units)

            };
        }


    }
}
