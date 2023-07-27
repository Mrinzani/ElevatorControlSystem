using System.ComponentModel;

namespace House.Buildings.Elevators
{
    public class ElevatorCab
    {
        private static int _nextId = 1;

        public int Id { get; private set; }

        public int CurrentPosition { get; set; }

        public string Status { get; private set; }

        public int MaxWeight { get; set; }

        //private Dictionary<string>

        public ElevatorCab()
        {
            Status = StatusElevator.WorthOpenDoor;
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
            
            //if (MovementBetweenDoor())
        }

        public bool СallingOperator()
        {
            //()
            return true;
        }

        public bool MovementBetweenDoor()
        {
            return true;
        }

        public bool NoMovementBetweenDoor()
        {
            return false;
        }

        public enum StatusElevator
        {
            [Description("Едет вверх")]
            MoveUp,
            [Description("Едет вниз")]
            MoveDown,
            [Description("Открывает двери")]
            OpenDoor,
            [Description("Закрывает двери")]
            CloseDoor,
            [Description("Стоит с открытыми дверями")]
            WorthOpenDoor
        }
    }
}
