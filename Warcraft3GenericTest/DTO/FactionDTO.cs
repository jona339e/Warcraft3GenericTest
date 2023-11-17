using Warcraft3GenericTest.Interfaces;

namespace Warcraft3GenericTest.DTO
{
    public class FactionDTO: IIncludeName
    {
        public string Name { get; set; }
        public ICollection<RaceDTO>? Race { get; set; } = new List<RaceDTO>();
    }

}
