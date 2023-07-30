using House.Building.Floors;
using House.Buildings.Elevators;
using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;

namespace House
{
    public class House
    {
        private readonly Random _random;
        private readonly Build _building;
        private SemaphoreSlim _semaphoreSlim;
        
        public House() 
        {
            int maxTask = 2;
            int maxFloors = 20;
            _building = CreateBuilding("Многоквартирный дом", maxFloors);
            _semaphoreSlim = new SemaphoreSlim(maxTask);
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

                Console.WriteLine("\nДисплей");

                foreach (var floor in _building.Elevator)
                {
                    Console.WriteLine($"Лифт {floor.Id} находится на {floor.CurrentPosition} этаже.");
                }

                Console.WriteLine("\nВызвать лифт? y/n");
                string callLift = Console.ReadLine();

                if (callLift != "y") continue;

                RunCallLiftAsync(currentFloor);
                //Thread.Sleep(1);
                //RunCallLiftAsync(5);
                //Thread.Sleep(1);
                //RunCallLiftAsync(7);

                //Console.ReadKey();
                //if (lift.IsCompleted)
                //{
                //    if (currentFloor == 1)
                //    {
                //        Console.WriteLine("Выберете этаж на который хотите подняться");

                //        foreach (Floor floor in _building.Floor)
                //        {
                //            if (floor.Number > currentFloor)
                //            {
                //                Console.WriteLine(floor.Number);
                //            }
                //        }
                //    }

                //    else if (currentFloor > 1)
                //    {
                //        Console.WriteLine("Выберете этаж на который хотите спуститься");
                //        Console.ReadLine();
                //    }
                //}
            }
        }

        private async Task RunCallLiftAsync(int currentFloor)
        {
            await _semaphoreSlim.WaitAsync();
            try
            {
                await _building.Floor[currentFloor].CallElevatorButton(_building.Elevator);
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }

        private async Task RandomEvent()
        {
            int chanceEvent = _random.Next(0, 100);
            if (!(chanceEvent <= 20)) return;

            Console.WriteLine("Ещё один житель дома вызвал лифт");
            Console.WriteLine("Введите этаж на котором житель вызвал лифт");
            int currentFloor = InputFloor();

            await RunCallLiftAsync(currentFloor);
        }

        private int InputFloor(int defaultFloor = -1)
        {
            Console.Write("\nЭтаж: ");

            string floor = Console.ReadLine();

            bool parseResult = int.TryParse(floor, out int currentFloor);

            if(!parseResult) return defaultFloor;

            return currentFloor;
        }

        //private Task CallLift( int floor)
        //{
        //    return _building.Floor[floor].CallElevatorButton(_building.Elevator);
        //}

        private static Build CreateBuilding(string NameBuiding, int SumFloor)
        {
            return new Build
            {
                Name = NameBuiding,
                Floor = Floors(SumFloor),
                Elevator = SumElevator()
            };
        }

        private static List<ElevatorCab> SumElevator()
        {
            return new List<ElevatorCab>
            {
                new ElevatorCab{Id = 1, MaxWeight = 400},
                new ElevatorCab{Id = 2, MaxWeight = 200}
            };
        }

        private static List<Floor> Floors(int NumberFloor)
        {
            List<Floor> floors = new List<Floor>();

            for (int i = 1; i <= NumberFloor; i++)
            {
                floors.Add(new Floor{ Number = i });
            }

            return floors;
        }
    }
}
