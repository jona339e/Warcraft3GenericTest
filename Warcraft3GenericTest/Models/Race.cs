using Warcraft3GenericTest.Interfaces;

namespace Warcraft3GenericTest.Models
{
    public class Race: ITestEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Building>? Buildings { get; set; }
        public ICollection<Faction> Factions { get; set; }
        public ICollection<Unit>? Units { get; set; }

    }
}
