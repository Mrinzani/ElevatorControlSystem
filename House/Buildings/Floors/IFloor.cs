using House.Buildings.Elevators;

namespace House.Building.Floors
{
    public interface IFloor
    {
        int Number { get; set; }
        bool StatusButton { get; set; }
        ElevatorCab CallElevatorButton(List<ElevatorCab> elevators);
        ElevatorCab CallElevatorButton(ElevatorCab elevator);
        List<int> DisplayElevator(List<ElevatorCab> elevators);
    }
}
