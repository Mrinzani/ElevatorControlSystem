using House.Building.Floors;
using System;
using System.ComponentModel;

namespace House.Buildings.Elevators
{
    public class ElevatorCab : IElevatorCab
    {
        public int Id { get; set; }
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

        public void SelectFloor(int floor)
        {

        }

        public async Task<ElevatorCab> PressFloorButton(int floor)
        {
            floor = floor - 1;
            int currentFloor = CurrentPosition;
            string description = GetStatus();

            if (currentFloor == floor)
            {
                await Console.Out.WriteLineAsync($"Лифт {Id} на {floor} этаже {description}.\n");
                return this;
            }

            Status = StatusElevator.CloseDoor;
            Status = currentFloor < floor ? Status = StatusElevator.MoveUp : StatusElevator.MoveDown;
            await Console.Out.WriteLineAsync($"Лифт {Id} {GetStatus()} с {currentFloor} этажа на {floor} этаж.\n");

            int delayInSeconds = 1;
            int step = currentFloor < floor ? 1 : -1;

            while (currentFloor != floor)
            {
                Thread.Sleep(delayInSeconds * 1000);
                await Console.Out.WriteLineAsync($"Лифт {Id} проезжает {currentFloor} этаж.\n");
                currentFloor += step;
            }

            CurrentPosition = currentFloor;
            Status = StatusElevator.OpenDoor;
            await Console.Out.WriteLineAsync($"Лифт {Id} прибыл на {currentFloor} этаж и {description}.\n");
            Status = StatusElevator.WorthOpenDoor;
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
