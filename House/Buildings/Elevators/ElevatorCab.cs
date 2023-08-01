using House.Building.Floors;
using System.ComponentModel;

namespace House.Buildings.Elevators
{
    public class ElevatorCab : IElevatorCab
    {
        public int Id { get; set; }
        public int CurrentPosition { get; private set; }
        public string ElevatorStatus {get; private set;}
        public StatusElevator Status { get; private set; }
        public int MaxWeight { get; set; }
        private bool _movementDoor{ get; set;}
        private int _nextPosition { get; set; }

        public ElevatorCab(int defaulfPositionElevator)
        {
            CurrentPosition = defaulfPositionElevator;
            Status = StatusElevator.WorthOpenDoor;
        }

        public void SelectFloor(List<Floor> floors, int nextFloor)
        {
            if (CurrentPosition == nextFloor)
            {
                Console.WriteLine($"Вы уже находитесь на текущем этаже");
                return;
            }

            if (!(CurrentPosition == 1))
            {
                Console.WriteLine($"Доступные к выбору этажи: ");
                foreach (var floor in floors)
                {
                    if (floor.Number < nextFloor)
                    {
                        Console.WriteLine($"{floor.Number}");
                    }
                }
            }

            foreach (var floor in floors)
            {
                Console.WriteLine($"{floor.Number}");
            }
        }

        public ElevatorCab PressFloorButton(int floor)
        {
            int delay = 500;
            int currentFloor = CurrentPosition;

            if (currentFloor == floor)
            {
                Console.WriteLine($"Лифт {Id} на {floor} этаже {GetStatus()}.\n");
                return null;
            }
            Thread.Sleep(delay);
            Status = StatusElevator.CloseDoor;
            Console.WriteLine($"Лифт {Id} {GetStatus()}\n");
            Thread.Sleep(delay);
            Status = currentFloor < floor ? Status = StatusElevator.MoveUp : StatusElevator.MoveDown;
            Console.WriteLine($"Лифт {Id} {GetStatus()} с {currentFloor} этажа на {floor} этаж.\n");

            int step = currentFloor < floor ? 1 : -1;

            while (currentFloor != floor)
            {
                Thread.Sleep(delay);
                Console.WriteLine($"Лифт {Id} проезжает {currentFloor} этаж.\n");
                currentFloor += step;
            }

            CurrentPosition = currentFloor;
            Status = StatusElevator.OpenDoor;
            Thread.Sleep(delay);
            Console.WriteLine($"Лифт {Id} прибыл на {currentFloor} этаж и {GetStatus()}.\n");
            Thread.Sleep(delay);
            Status = StatusElevator.WorthOpenDoor;
            Console.WriteLine($"Лифт {Id} {GetStatus()}.\n");
            return this;
        }

        public bool OpenDoor()
        {
            if(CurrentPosition == _nextPosition)
            {
                return true;
            }
            return false;
        }

        public bool CloseDoor()
        {
            if (!_movementDoor) return true;
            return false;
        }

        public bool СallingOperator()
        {
            return true;
        }

        public ElevatorCab MovementBetweenDoor()
        {
            _movementDoor = true;
            return this;
        }

        public ElevatorCab NoMovementBetweenDoor()
        {
            _movementDoor = false;
            return this;
        }

        public string GetStatus()
        {
            var fieldInfo = Status.GetType().GetField(Status.ToString());
            var attributes = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
            {
                return ((DescriptionAttribute)attributes[0]).Description;
            }
            else
            {
                return Status.ToString();
            }
        }

        public enum StatusElevator
        {
            [Description("Движется вверх")]
            MoveUp,
            [Description("Движется вниз")]
            MoveDown,
            [Description("Открывает двери")]
            OpenDoor,
            [Description("Закрывает двери")]
            CloseDoor,
            [Description("Стоит с открытыми дверями")]
            WorthOpenDoor,
        }
    }
}
