using Warcraft3GenericTest.Interfaces;

namespace Warcraft3GenericTest.Models
{
    public class Building: ITestEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Unit>? Units { get; set; }
        public int RaceId { get; set; }
        public Race Race { get; set; }
    }
}
