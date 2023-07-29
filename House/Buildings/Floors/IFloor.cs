using House.Buildings.Elevators;

namespace House.Building.Floors
{
    public interface IFloor
    {
        int Number { get; set; }
        bool StatusButton { get; set; }
        Task<ElevatorCab> CallElevatorButton(List<ElevatorCab> elevators);
        //List<int> DisplayElevator(List<ElevatorCab> elevators);
    }
}
