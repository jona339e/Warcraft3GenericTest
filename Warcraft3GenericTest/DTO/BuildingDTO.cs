using Warcraft3GenericTest.Interfaces;

namespace Warcraft3GenericTest.DTO
{
    public class BuildingDTO: IIncludeName
    {
        public string Name { get; set; }
        public RaceDTO Race { get; set; }
        public ICollection<UnitDTO>? Units{ get; set; } = new List<UnitDTO>();
        // Other properties specific to creating a Building
    }


}
