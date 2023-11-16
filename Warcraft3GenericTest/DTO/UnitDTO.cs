using Warcraft3GenericTest.Interfaces;

namespace Warcraft3GenericTest.DTO
{
    public class UnitDTO: IIncludeName
    {
        public string Name { get; set; }
        public BuildingDTO Building { get; set; }
        // Other properties specific to creating a Unit
    }

}
