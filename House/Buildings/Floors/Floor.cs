using House.Buildings;
using House.Buildings.Elevators;

namespace House.Building.Floors
{
    public class Floor : IFloor
    {
        public int Number { get; set; }
        public bool StatusButton { get; set; }

        public async Task<ElevatorCab> CallElevatorButton(List<ElevatorCab> elevators)
        {
            if (elevators.Count == 0) return null;

            var tasks = new List<Task<ElevatorCab>>();

            while (true)
            {
                foreach (var elevator in elevators)
                {
                    if (elevator.Status == ElevatorCab.StatusElevator.WorthOpenDoor)
                    {
                        tasks.Add(Task.Run(async () =>
                        {
                            var pressButton = await elevator.PressFloorButton(Number);
                            return pressButton;
                        }));
                        break;
                    }
                    
                }
                if (tasks.Count > 0)
                {
                    break;
                }
            }
            return null;
        }
        
        //public List<int> DisplayElevator(List<ElevatorCab> elevators)
        //{
        //    List<int> list = new List<int>();

        //    foreach(var elevator in elevators)
        //    {
        //        list.Add(elevator.CurrentPosition);
        //    }

        //    return list;
        //}
    }
}