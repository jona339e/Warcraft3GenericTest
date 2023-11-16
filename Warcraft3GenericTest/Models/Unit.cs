using Warcraft3GenericTest.Interfaces;

namespace Warcraft3GenericTest.Models
{
    public class Unit: ITestEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int FoodCost { get; set; }
        public int GoldCost { get; set; }
        public int LumberCost { get; set; }
        public int RaceId { get; set; }
        public Race Race { get; set; }
        public int BuildingId { get; set; }
        public Building Building { get; set; }


    }
}
