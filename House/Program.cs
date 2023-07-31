using House.Building.Floors;
using House.Buildings;
using House.Buildings.CreateBuild;
using House.Buildings.Elevators;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace House
{
    class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.Services.GetRequiredService<House>().Start();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddTransient<IElevatorCab, ElevatorCab>();
                    services.AddTransient<IFloor, Floor>();
                    services.AddTransient<IBuild, Build>();
                    services.AddScoped<ICreateBuild, CreateBuild>();
                    services.AddSingleton<House>();
                });
        }
    }
}