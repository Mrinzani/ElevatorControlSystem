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
            var buiding = CreateBuilding("Аптека",20);

            
            Console.WriteLine(buiding.Floors.Count());

            //var host = CreateHostBuilder(args).Build();
            //host.Services.GetRequiredService<>
        }

        private static Build CreateBuilding(string NameBuiding,int SumFloor)
        {
            return new Build
            {
                Name = NameBuiding,
                Floors = Floors(SumFloor)
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

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddScoped<IElevatorCab, ElevatorCabOne>();
                    services.AddScoped<IFloor, Floor>();
                });
        }
    }
}