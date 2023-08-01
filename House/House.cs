using House.Building.Floors;
using House.Buildings.CreateBuild;
using House.Buildings.Elevators;

namespace House
{
    public class House
    {
        private readonly Random _random;
        private readonly Build _building;

        public House(ICreateBuild createBuild)
        {
            int maxFloors = 20;
            _building = createBuild.Building("Многоквартирный дом", maxFloors);
            _random = new Random();
        }

        public void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите этаж на котором находитесь");

                int currentFloor = InputFloor();

                if (currentFloor > _building.Floor.Count)
                {
                    Console.WriteLine("Данного этажа не существует");
                    continue;
                }

                Console.Clear();
                WatchDisplay();

                bool isTrue = CheckOneFloor(currentFloor);

                if (isTrue)
                {
                    Console.WriteLine("Нажмите пробел.....");
                    Console.ReadKey();
                    continue;
                }

                Console.WriteLine("\nВызвать лифт? y/n");
                string callLift = Console.ReadLine();
                Console.Clear();

                if (callLift != "y")
                    continue;

                CheckAllFloor(currentFloor);

                Console.WriteLine("Нажмите пробел.....");
                Console.ReadKey();
            }
        }

        private void CheckAllFloor(int currentFloor)
        {
            var resultRunCallLift = RunCallLift(currentFloor);
            ChoiceFloor(currentFloor, resultRunCallLift);
        }

        private bool CheckOneFloor(int currentFloor)
        {
            foreach (var elevator in _building.Elevator)
            {
                if (elevator.CurrentPosition != currentFloor) continue;
                ChoiceFloor(currentFloor, elevator);
                return true;
            }
            return false;
        }

        private void WatchDisplay()
        {
            Console.WriteLine("Дисплей");

            foreach (var floor in _building.Elevator)
            {
                Console.WriteLine($"Лифт {floor.Id} находится на {floor.CurrentPosition} этаже.");
            }
        }

        private void ChoiceFloor(int currentFloor, ElevatorCab resultRunCallLift)
        {
            int minFloor = 1;
            int maxFloor = 0;

            switch (currentFloor)
            {
                case 1:
                    Console.WriteLine("\nВыберете этаж на который хотите подняться");
                    maxFloor = PrintFloor(currentFloor, MoveLift.Up);
                    break;
                default:
                    Console.WriteLine("\nВыберете этаж на который хотите спуститься");
                    maxFloor = PrintFloor(currentFloor, MoveLift.Down);
                    break;
            }

            Console.WriteLine();
            int parseFloor = InputFloor(minFloor);

            if (maxFloor < parseFloor)
            {
                Console.WriteLine("Пожалуйста выберите корректный этаж из списка");
                return;
            }
            
            RunCallLift(parseFloor, resultRunCallLift);
        }

        private int PrintFloor(int currentFloor, MoveLift moveLift)
        {
            int maxFloor = 0;
            switch (moveLift) 
            {
                case MoveLift.Up:
                    foreach (Floor floor in _building.Floor)
                    {
                        if (floor.Number > currentFloor)
                        {
                            Console.Write($"{floor.Number} ");
                        }
                    }
                    maxFloor = _building.Floor.Count();
                    return maxFloor;
                default:
                    foreach (Floor floor in _building.Floor)
                    {
                        if (floor.Number < currentFloor)
                        {
                            Console.Write($"{floor.Number} ");
                            maxFloor = maxFloor < floor.Number ? floor.Number : maxFloor;
                        }
                    }
                    return maxFloor;
            }
        }

        private ElevatorCab RunCallLift(int currentFloor)
        {
            return _building.Floor[currentFloor-1].CallElevatorButton(_building.Elevator);
        }

        private ElevatorCab RunCallLift(int currentFloor, ElevatorCab resultRunCallLift)
        {
            return _building.Floor[currentFloor-1].CallElevatorButton(resultRunCallLift);
        }

        private int InputFloor(int defaultFloor = -1)
        {
            Console.Write("\nЭтаж: ");
            string floor = Console.ReadLine();
            bool parseResult = int.TryParse(floor, out int currentFloor);

            if (!parseResult) return defaultFloor;

            return currentFloor;
        }

        enum MoveLift
        {
            Up,
            Down,
        }
    }
}
