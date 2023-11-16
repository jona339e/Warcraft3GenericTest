using Warcraft3GenericTest.Interfaces;

namespace Warcraft3GenericTest.DTO
{
    public class BuildingDTO: IIncludeName
    {
        public string Name { get; set; }
        public ICollection<UnitDTO> Units{ get; set; }
        public ICollection<RaceDTO> Races { get; set; }
        // Other properties specific to creating a Building
    }


}
