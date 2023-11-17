using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using Warcraft3GenericTest.Interfaces;
using Warcraft3GenericTest.Models;
using Warcraft3GenericTest.DTO;

namespace Warcraft3GenericTest.Controllers
{
    public class FactionController : GenericController<Faction, FactionDTO>
    {
        public FactionController(IGenericRepository<Faction> repository) : base(repository)
        {
        }
        // Override the mapping method for FactionDTO
        protected override Faction MapCreateDTOToEntity(FactionDTO createDTO)
        {
            return new Faction
            {
                Name = createDTO.Name,
                Races = createDTO.Race?.Select(raceDTO => MapRaceDTOToRace(raceDTO)).ToList()
            };
        }


        private Race MapRaceDTOToRace(RaceDTO raceDTO)
        {
            return new Race
            {
                Name = raceDTO.Name,
                Factions = new List<Faction> { MapFactionDTOToFaction(raceDTO.Faction) },
                Buildings = raceDTO.Building?.Select(buildingDTO => MapBuildingDTOToBuilding(buildingDTO)).ToList(),
                Units = raceDTO.Unit?.Select(unitDTO => MapUnitDTOToUnit(unitDTO)).ToList()
            };
        }

        // Add a method to map BuildingDTO to Building
        private Building MapBuildingDTOToBuilding(BuildingDTO buildingDTO)
        {
            return new Building
            {
                Name = buildingDTO.Name,
                Race = MapRaceDTOToRace(buildingDTO.Race),
                Units = buildingDTO.Units?.Select(unitDTO => MapUnitDTOToUnit(unitDTO)).ToList()
            };
        }

        private Unit MapUnitDTOToUnit(UnitDTO unitDTO)
        {
            return new Unit
            {
                Name = unitDTO.Name,
                GoldCost = unitDTO.GoldCost,
                LumberCost = unitDTO.LumberCost,
                Health = unitDTO.Health,
                Damage = unitDTO.Damage,
                Race = MapRaceDTOToRace(unitDTO.Race),
                Building = MapBuildingDTOToBuilding(unitDTO.Building)
            };
        }


        private Faction MapFactionDTOToFaction(FactionDTO factionDTO)
        {
            return new Faction
            {
                Name = factionDTO.Name,
                Races = factionDTO.Race?.Select(raceDTO => MapRaceDTOToRace(raceDTO)).ToList()
            };
        }

    }
}
