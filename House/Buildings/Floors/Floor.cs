using House.Buildings;
using House.Buildings.Elevators;

namespace House.Building.Floors
{
    public class Floor :IFloor
    {
        public int Number { get; set; }
        public bool StatusButton { get; set; }
        public void CallElevatorButton()
        {
            
        }
        
        public List<int> DisplayElevator(List<ElevatorCab> elevators)
        {
            List<int> list = new List<int>();

            foreach(var elevator in elevators)
            {
                list.Add(elevator.CurrentPosition);
            }

            return list;
        }

    }
}