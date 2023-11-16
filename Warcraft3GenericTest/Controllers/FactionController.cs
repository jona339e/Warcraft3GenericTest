using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using Warcraft3GenericTest.Interfaces;
using Warcraft3GenericTest.Models;
using Warcraft3GenericTest.DTO;

namespace Warcraft3GenericTest.Controllers
{
    public class FactionController : GenericController<Faction, FactionDTO>
    {
        public FactionController(IGenericRepository<Faction> repository) : base(repository)
        {
        }

        protected override Func<IQueryable<Faction>, IIncludableQueryable<Faction, object>>[] GetIncludes()
        {
            return new Func<IQueryable<Faction>, IIncludableQueryable<Faction, object>>[]
            {
                query => query.Include(u => u.Races),

            };
        }
    }
}
