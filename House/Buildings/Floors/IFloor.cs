using House.Buildings.Elevators;

namespace House.Building.Floors
{
    public interface IFloor
    {
        int Number { get; set; }
        bool StatusButton { get; set; }
        void CallElevatorButton(ElevatorCab elevatorcab);
        List<int> DisplayElevator(List<ElevatorCab> elevators);
    }
}
