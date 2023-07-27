using ElevatorControlSystem.Building.Floors;

namespace ElevatorControlSystem.Buildings
{
    public interface IBuild
    {
        int Id { get; set; }
        string Name { get; set; }
        List<Floor> Floors { get; set; }
    }
}
