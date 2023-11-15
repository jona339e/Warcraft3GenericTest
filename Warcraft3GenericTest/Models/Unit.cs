namespace Warcraft3GenericTest.Models
{
    public class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int FoodCost { get; set; }
        public int GoldCost { get; set; }
        public int LumberCost { get; set; }
        public Race Race { get; set; }

    }
}
