namespace Warcraft3GenericTest.Models
{
    public class Race
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Building> Building { get; set; }
        
    }
}
