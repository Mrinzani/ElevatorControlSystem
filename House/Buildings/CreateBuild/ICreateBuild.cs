using House.Buildings.Elevators;

namespace House.Buildings.CreateBuild
{
    public interface ICreateBuild
    {
        Build Building(string NameBuiding, int SumFloor);
    }
}
