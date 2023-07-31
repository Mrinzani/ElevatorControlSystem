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
                Console.WriteLine("Введите этаж на котором находитесь");

                int currentFloor = InputFloor();

                if (currentFloor > _building.Floor.Count)
                {
                    Console.WriteLine("Данного этажа не существует");
                    continue;
                }

                Console.Clear();
                WatchDisplay();

                bool isTrue = CheckOneFloor(currentFloor).Result;

                if (isTrue)
                {
                    Console.ReadKey();
                    continue;
                }

                Console.WriteLine("\nВызвать лифт? y/n");
                string callLift = Console.ReadLine();
                Console.Clear();

                if (callLift != "y")
                    continue;

                CheckAllFloor(currentFloor);
                Console.ReadLine();
            }
        }

        private async Task CheckAllFloor(int currentFloor)
        {
            var resultRunCallLift = RunCallLift(currentFloor);
            ChoiceFloor(currentFloor, resultRunCallLift);
        }

        private async Task<bool> CheckOneFloor(int currentFloor)
        {
            int randomAttempt = 1;
            foreach (var elevator in _building.Elevator)
            {
                if (elevator.CurrentPosition == currentFloor)
                {
                    bool random = _random.Next(2) == 0;
                    if (randomAttempt != 0)
                    {
                        if (random)
                        {
                            ChoiceFloor(currentFloor, elevator);
                            return true;
                        }
                        randomAttempt--;
                        return false;
                    }
                    ChoiceFloor(currentFloor, elevator);
                    return true;
                }
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

            if (currentFloor == 1)
            {
                Console.WriteLine("\nВыберете этаж на который хотите подняться");

                foreach (Floor floor in _building.Floor)
                {
                    if (floor.Number > currentFloor)
                    {
                        Console.Write($"{floor.Number} ");
                    }
                }
                Console.WriteLine();
                int parseFloor = InputFloor(minFloor);
                RunCallLift(parseFloor, resultRunCallLift);
            }
            else
            {
                Console.WriteLine("\nВыберете этаж на который хотите спуститься");

                int lastFloor = currentFloor - 1;

                foreach (Floor floor in _building.Floor)
                {
                    if (floor.Number < currentFloor)
                    {
                        Console.Write($"{floor.Number} ");
                    }
                }
                Console.WriteLine();
                int parseFloor = InputFloor(minFloor);
                RunCallLift(parseFloor, resultRunCallLift);
            }
        }

        private ElevatorCab RunCallLift(int currentFloor)
        {
            return _building.Floor[currentFloor].CallElevatorButton(_building.Elevator);
        }

        private ElevatorCab RunCallLift(int currentFloor, ElevatorCab resultRunCallLift)
        {
            return _building.Floor[currentFloor].CallElevatorButton(resultRunCallLift);
        }

        private bool RandomEvent(int chanceinPercent)
        {
            int chanceEvent = _random.Next(0, 100);
            return chanceEvent <= chanceinPercent;
        }

        private int InputFloor(int defaultFloor = -1)
        {
            Console.Write("\nЭтаж: ");

            string floor = Console.ReadLine();

            bool parseResult = int.TryParse(floor, out int currentFloor);

            if(!parseResult) return defaultFloor;

            return currentFloor;
        }
    }
}
