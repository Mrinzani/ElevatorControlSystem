using House.Building.Floors;
using House.Buildings.Elevators;

namespace House.Buildings.CreateBuild
{
    public class CreateBuild : ICreateBuild
    {
        public Build Building(string NameBuiding, int SumFloor)
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
            int defaultPosition = 1;
            return new List<ElevatorCab>
            {
                new ElevatorCab(defaultPosition){Id = 1, MaxWeight = 400},
                new ElevatorCab(defaultPosition){Id = 2, MaxWeight = 200}
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
    }
}
