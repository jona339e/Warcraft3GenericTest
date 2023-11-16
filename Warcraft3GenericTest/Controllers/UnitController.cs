using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Warcraft3GenericTest.DTO;
using Warcraft3GenericTest.Interfaces;
using Warcraft3GenericTest.Models;

namespace Warcraft3GenericTest.Controllers
{
    public class UnitController : GenericController<Unit, UnitDTO>
    {

        public UnitController(IGenericRepository<Unit> repository) : base(repository)
        {
        }

        // Override to specify includes for UnitController
        protected override Func<IQueryable<Unit>, IIncludableQueryable<Unit, object>>[] GetIncludes()
        {
            return new Func<IQueryable<Unit>, IIncludableQueryable<Unit, object>>[]
            {
                query => query.Include(u => u.Race),
                query => query.Include(u => u.Building),

            };
        }



    }
}
