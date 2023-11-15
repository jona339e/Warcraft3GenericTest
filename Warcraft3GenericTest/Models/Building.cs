namespace Warcraft3GenericTest.Models
{
    public class Building
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Unit> Unit { get; set; }
    }
}
