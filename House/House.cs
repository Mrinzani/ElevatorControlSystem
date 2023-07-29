using House.Building.Floors;
using House.Buildings;
using House.Buildings.Elevators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    public class House
    {
        private readonly IBuild _build;
        private readonly IFloor _floor;

        public House(IBuild build, IFloor floor) 
        { 
            _build = build;
            _floor = floor;
        }

        public void Start()
        {
            var building = CreateBuilding("Аптека", 20);

            Console.WriteLine($"Название здания: {building.Name}\n" +
                    $"Количество этажей: {building.Floor.Count()}\n" +
                    $"Количество лифтов: {building.Elevator.Count()}\n" +
                    $"Статус первого лифта: {building.Elevator[0].GetStatus()}\n" +
                    $"Статус второго лифта: {building.Elevator[1].GetStatus()}\n"
                    );

            CallLift(building, 5);

            Thread.Sleep(100);//Задержка нажатия второй кнопки

            CallLift(building, 10);

            Thread.Sleep(100);//имитация нажатия третьей кнопки

            CallLift(building, 15);

            Console.ReadKey();
        }

        private async Task CallLift(Build building, int floor)
        {
            await building.Floor[floor].CallElevatorButton(building.Elevator);
        }
    
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
