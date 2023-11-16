using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using Warcraft3GenericTest.Interfaces;
using Warcraft3GenericTest.Models;
using Warcraft3GenericTest.DTO;

namespace Warcraft3GenericTest.Controllers
{
    public class BuildingController : GenericController<Building, BuildingDTO> 
    {
        public BuildingController(IGenericRepository<Building> repository) : base(repository)
        {
        }

        // Override to specify includes for UnitController
        protected override Func<IQueryable<Building>, IIncludableQueryable<Building, object>>[] GetIncludes()
        {
            return new Func<IQueryable<Building>, IIncludableQueryable<Building, object>>[]
            {
                query => query.Include(u => u.Units),
                query => query.Include(u => u.Race),

            };
        }

        // Override the mapping method for Building entity
        protected override Building MapCreateDTOToEntity(BuildingDTO createDTO)
        {
            // Implement the specific mapping logic for Building entity
            // Example: Property by property mapping
            return new Building
            {
                Name = createDTO.Name,
                Units = new List<Unit>(),
                Race = new Race()
            };
        }

    }
}
