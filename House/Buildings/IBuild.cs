using House.Building.Floors;
using House.Buildings.Elevators;

namespace House.Buildings
{
    public interface IBuild
    {
        int Id { get; set; }
        string Name { get; set; }
        List<Floor> Floor { get; set; }
        public List<ElevatorCab> Elevator { get; set; }
    }
}
