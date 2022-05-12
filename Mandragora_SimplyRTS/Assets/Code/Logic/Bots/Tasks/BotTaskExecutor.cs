using Code.Logic.Buildings;
using Code.Logic.Buildings.Factory;
using UnityEngine;

namespace Code.Logic.Bots.Tasks
{
  public class BotTaskExecutor : MonoBehaviour
  {
    public ITask CurrentTask;

    [SerializeField]
    private BotMover _mover;
    
    public void SetMoveToPositionTask(Vector3 at)
    {
      CurrentTask = new MoveToTask(at);
      
      at.y = transform.position.y;
      _mover.Move(at);
    }

    public void SetBuildingInteractionTask(Building building)
    {
      Vector3 at = building.transform.position;
      at.y = transform.position.y;
      
      CurrentTask = new InteractWithBuildingTask(at, building);
      _mover.Move(at);
    }

    public void InformBuildingProximity(Building building)
    {
      if (CurrentTask.Type == TaskType.InteractWithBuilding)
      {
        var task = CurrentTask as InteractWithBuildingTask;
        
        if(task.BuildingToInteract == building)
          building.Interact(gameObject);
      }
    }
  }
}