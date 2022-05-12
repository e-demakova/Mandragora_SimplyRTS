using Code.Logic.Buildings;
using UnityEngine;

namespace Code.Logic.Bots.Tasks
{
  public class InteractWithBuildingTask : ITask
  {
    public TaskType Type => TaskType.InteractWithBuilding;
    public Vector3 Destination;
    public Building BuildingToInteract;

    public InteractWithBuildingTask(Vector3 destination, Building buildingToInteract)
    {
      Destination = destination;
      BuildingToInteract = buildingToInteract;
    }
  }
}