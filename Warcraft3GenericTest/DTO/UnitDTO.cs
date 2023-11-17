using Warcraft3GenericTest.Interfaces;

namespace Warcraft3GenericTest.DTO
{
    public class UnitDTO: IIncludeName
    {
        public string Name { get; set; }
        public int GoldCost { get; set; }
        public int LumberCost { get; set; }
        public float Health { get; set; }
        public float Damage { get; set; }
        public BuildingDTO Building { get; set; }
        public RaceDTO Race { get; set; }
    }

}
