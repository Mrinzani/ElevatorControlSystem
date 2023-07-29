using House.Building.Floors;
using static House.Buildings.Elevators.ElevatorCab;

namespace House.Buildings.Elevators
{
    public interface IElevatorCab
    {
        int CurrentPosition { get; }
        StatusElevator Status { get; }
        void PressFloorButton(int floor);
        ElevatorCab ChooseFloorButton(int floor);
        bool OpenDoor();
        bool CloseDoor();
        bool СallingOperator();
        ElevatorCab MovementBetweenDoor();
        ElevatorCab NoMovementBetweenDoor();
        string GetStatus();
    }
}
