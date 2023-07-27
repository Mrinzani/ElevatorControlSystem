namespace House.Buildings.Elevators
{
    public class ElevatorCab : IElevatorCab
    {
        private static int _nextId = 1;
        public int Id { get; private set; }
        public int CurrentPosition { get; set; }
        public string Status { get; set; }
        public int MaxWeight { get; set; }

        public ElevatorCab()
        {
            Id = _nextId++;
        }

        public void ChooseFloorButton()
        {

        }
        public void OpenDoor()
        {

        }

        public void CloseDoor()
        {

        }

        public void СallingOperator()
        {

        }

        public void MovementBetweenDoor()
        {

        }

        public void NoMovementBetweenDoor()
        {

        }

    }
}
