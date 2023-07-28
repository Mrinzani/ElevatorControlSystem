using House.Building.Floors;
using System.ComponentModel;

namespace House.Buildings.Elevators
{
    public class ElevatorCab : IElevatorCab
    {
        public int CurrentPosition { get; set; }

        public StatusElevator Status { get; private set; }

        public int MaxWeight { get; set; }

        public ElevatorCab()
        {
            int defaulfPositionElevator = 1;
            CurrentPosition = defaulfPositionElevator;
            Status = StatusElevator.WorthOpenDoor;
        }

        public void ChooseFloorButton()
        {
            return ;
        }

        public bool OpenDoor()
        {
            return true;
        }

        public bool CloseDoor()
        {
            if (NoMovementBetweenDoor()) return true;
            return false;
        }

        public bool СallingOperator()
        {
            return true;
        }

        public bool MovementBetweenDoor()
        {
            return true;
        }

        public bool NoMovementBetweenDoor()
        {
            return true;
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
