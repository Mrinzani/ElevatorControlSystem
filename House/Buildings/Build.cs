using House.Building.Floors;

namespace House.Buildings.Elevators
{
    public class Build : IBuild
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Floor> Floor { get; set; }
        public List<ElevatorCab> Elevator { get; set; }
    }
}
