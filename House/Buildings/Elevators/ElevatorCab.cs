using House.Building.Floors;
using System;
using System.ComponentModel;

namespace House.Buildings.Elevators
{
    public class ElevatorCab : IElevatorCab
    {
        public int CurrentPosition { get; private set; }
        public StatusElevator Status { get; private set; }
        public int MaxWeight { get; set; }
        private bool movementDoor{ get; set;}
        private int nextPosition { get; set; }

        public ElevatorCab()
        {
            int defaulfPositionElevator = 1;
            CurrentPosition = defaulfPositionElevator;
            Status = StatusElevator.WorthOpenDoor;
        }
        
        public bool SetCurrentPosition(Floor floor)
        {

            if (!CloseDoor()) return false;

            if(CurrentPosition== 1) 

            Status = StatusElevator.CloseDoor;
            Status = StatusElevator.MoveUp;

            return true;

        }

        public void PressFloorButton(int floor)
        {
            int currentFloor = CurrentPosition;
            string description = GetStatus();

            if (currentFloor == floor)
            {
                
                Console.WriteLine($"Лифт на {floor} этаже {description}.");
                return;
            }

            string direction = currentFloor < floor ? "вверх" : "вниз";
            Console.WriteLine($"Лифт движется {direction} с {currentFloor} этажа на {floor} этаж.\n");

            int delayInSeconds = 1;
            int step = currentFloor < floor ? 1 : -1;

            while (currentFloor != floor)
            {
                Thread.Sleep(delayInSeconds * 1000);
                currentFloor += step;
                Console.WriteLine($"Лифт проезжает {currentFloor} этаж.");
            }

            CurrentPosition = currentFloor;
            Status = StatusElevator.WorthOpenDoor;
            Console.WriteLine($"Лифт прибыл на {currentFloor} этаж и {description}.");
        }

        public ElevatorCab ChooseFloorButton(int floor)
        {
            if(CurrentPosition == 1)
            {
                if (floor > CurrentPosition)
                {
                    Status = StatusElevator.MoveUp;
                }
            }
            else
            {
                if(CurrentPosition > floor)
                {
                    Status = StatusElevator.MoveDown;
                }
            }
            return this;
        }

        public bool OpenDoor()
        {
            if(CurrentPosition == nextPosition)
            {
                return true;
            }
            return false;
        }

        public bool CloseDoor()
        {
            if (!movementDoor) return true;
            return false;
        }

        public bool СallingOperator()
        {
            return true;
        }

        public ElevatorCab MovementBetweenDoor()
        {
            movementDoor = true;
            return this;
        }

        public ElevatorCab NoMovementBetweenDoor()
        {
            movementDoor = false;
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
            [Description("Едет вверх")]
            MoveUp,
            [Description("Едет вниз")]
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
