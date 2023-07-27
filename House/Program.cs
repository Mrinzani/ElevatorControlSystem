using House.Building.Floors;
using House.Buildings.Elevators;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace House
{
    class Program
    {
        public static void Main(string[] args)
        {
            var building = CreateBuilding("Аптека",20);

            Console.WriteLine($"Название здания: {building.Name}\n" +
                $"Количество этажей: {building.Floors.Count()}\n" +
                $"Количество лифтов: {building.Elevator.Count()}\n" +
                $"{building.Elevator[1].Status}"
                );
            Console.ReadKey();

            //var host = CreateHostBuilder(args).Build();
            //host.Services.GetRequiredService<>
        }

        private static Build CreateBuilding(string NameBuiding, int SumFloor)
        {
            return new Build
            {
                Name = NameBuiding,
                Floors = Floors(SumFloor),
                Elevator = SumElevator()
            };
        }
        private static List<ElevatorCab> SumElevator()
        {
            return new List<ElevatorCab>
            {
                new ElevatorCab{MaxWeight = 400},
                new ElevatorCab{MaxWeight = 200}
            };
        }

        private static List<Floor> Floors(int NumberFloor)
        {
            List<Floor> floors = new List<Floor>();

            for (int i = 1; i <= NumberFloor; i++)
            {
                floors.Add(new Floor { Number = i });
            }

            return floors;
        }

        //private static IHostBuilder CreateHostBuilder(string[] args)
        //{
        //    return Host.CreateDefaultBuilder(args)
        //        .ConfigureServices(services =>
        //        {
        //            services.AddScoped<IElevatorCab, ElevatorCab>();
        //            services.AddScoped<IFloor, Floor>();
        //        });
        //}
    }
}