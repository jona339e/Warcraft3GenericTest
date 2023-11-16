using Warcraft3GenericTest.Interfaces;

namespace Warcraft3GenericTest.DTO
{
    public class RaceDTO: IIncludeName
    {
        public string Name { get; set; }
        public FactionDTO Faction { get; set; }
        // Other properties specific to creating a Race
    }

}
