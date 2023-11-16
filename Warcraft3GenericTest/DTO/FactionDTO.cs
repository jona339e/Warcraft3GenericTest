using Warcraft3GenericTest.Interfaces;

namespace Warcraft3GenericTest.DTO
{
    public class FactionDTO: IIncludeName
    {
        public string Name { get; set; }
        // Other properties specific to creating a Faction
    }

}
