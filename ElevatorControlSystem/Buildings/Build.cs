using ElevatorControlSystem.Building.Floors;

namespace ElevatorControlSystem.Buildings.Elevators
{
    public class Build
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Floor> Floors { get; set; }
        public List<ElevatorCabOne> Elevator{get;set;}
    }
}
