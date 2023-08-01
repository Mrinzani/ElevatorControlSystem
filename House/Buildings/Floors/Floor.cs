using House.Buildings.Elevators;

namespace House.Building.Floors
{
    public class Floor : IFloor
    {
        public int Number { get; set; }
        public bool StatusButton { get; set; }

        public ElevatorCab CallElevatorButton(ElevatorCab elevator)
        {
            if (elevator== null) 
                return null;

            StatusButton = true;

            if (elevator.Status == ElevatorCab.StatusElevator.WorthOpenDoor)
            {
                ElevatorCab callElevatorButton = elevator.PressFloorButton(Number);
                StatusButton = false;
                return callElevatorButton;
            }

            StatusButton = false;
            return null;
        }

        public ElevatorCab CallElevatorButton(List<ElevatorCab> elevators)
        {
            if (elevators.Count == 0) 
                return null;

            StatusButton = true;

            foreach (var elevator in elevators)
            {
                if (elevator.Status == ElevatorCab.StatusElevator.WorthOpenDoor)
                {
                    ElevatorCab callElevatorButton = elevator.PressFloorButton(Number);
                    StatusButton = false;
                    return callElevatorButton;
                }
            }

            StatusButton = false;
            return null;
        }

        public List<int> DisplayElevator(List<ElevatorCab> elevators)
        {
            List<int> list = new List<int>();

            foreach (var elevator in elevators)
            {
                list.Add(elevator.CurrentPosition);
            }

            return list;
        }
    }
}