using Code.Logic.Buildings;

namespace Code.Logic.Bots.Tasks
{
  public class InteractWithBuildingTask : ITask
  {
    public Building BuildingToInteract;

    public bool Completed { get; set; }

    public InteractWithBuildingTask(Building buildingToInteract)
    {
      BuildingToInteract = buildingToInteract;
    }
  }
}