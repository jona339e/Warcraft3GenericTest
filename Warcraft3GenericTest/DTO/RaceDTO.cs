using Warcraft3GenericTest.Interfaces;

namespace Warcraft3GenericTest.DTO
{
    public class RaceDTO: IIncludeName
    {
        public string Name { get; set; }
        public FactionDTO Faction { get; set; }
        public ICollection<BuildingDTO>? Building { get; set; } = new List<BuildingDTO>();
        public ICollection<UnitDTO>? Unit { get; set; } = new List<UnitDTO>();
        // Other properties specific to creating a Race
    }

}
