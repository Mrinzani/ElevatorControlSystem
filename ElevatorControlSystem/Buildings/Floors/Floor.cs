namespace ElevatorControlSystem.Building.Floors
{
    public class Floor : IFloor
    {
        //public ElevatorCabOne ElevatorCabOne {get;set;}
        public int Id { get; set; }
        public int Number { get; set; }
        //public ElevatorCabOne
        public bool StatusButton { get; set; }

    }
}