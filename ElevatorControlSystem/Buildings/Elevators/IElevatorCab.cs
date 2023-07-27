namespace ElevatorControlSystem.Buildings.Elevators
{
    public interface IElevatorCab
    {
        int CurrentPosition { get; }
        string Status { get; }
        public void ChooseFloorButton();
        public void OpenDoor();
        void CloseDoor();
        void СallingOperator();
        void MovementBetweenDoor();
        void NoMovementBetweenDoor();
    }
}
