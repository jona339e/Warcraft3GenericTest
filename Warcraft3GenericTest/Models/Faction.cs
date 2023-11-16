using Warcraft3GenericTest.Interfaces;

namespace Warcraft3GenericTest.Models
{
    public class Faction: ITestEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Race> Races { get; set; }
    }
}
