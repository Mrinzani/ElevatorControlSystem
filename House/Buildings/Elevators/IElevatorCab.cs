using House.Building.Floors;
using static House.Buildings.Elevators.ElevatorCab;

namespace House.Buildings.Elevators
{
    public interface IElevatorCab
    {
        int CurrentPosition { get; }
        StatusElevator Status { get; }
        void ChooseFloorButton();
        bool OpenDoor();
        bool CloseDoor();
        bool СallingOperator();
        bool MovementBetweenDoor();
        bool NoMovementBetweenDoor();
    }
}
