using System;
using Code.Logic.Buildings;
using UnityEngine;

namespace Code.Logic.Bots.Tasks
{
  public class BotTaskExecutor : MonoBehaviour
  {
    public ITask CurrentTask;

    [SerializeField]
    private BotMover _mover;

    public Building NearBuilding { get; set; }

    private void FixedUpdate()
    {
      if (CurrentTask == null)
        return;

      ExecuteTask();
      
      if (CurrentTask.Completed)
        EndTask();
    }

    public void SetMoveToPositionTask(Vector3 at)
    {
      at.y = transform.position.y;

      CurrentTask = new MoveToDestinationTask(at);
      _mover.Move(at);
    }

    public void SetBuildingInteractionTask(Building building)
    {
      Vector3 at = building.transform.position;
      at.y = transform.position.y;

      CurrentTask = new InteractWithBuildingTask(building);
      _mover.Move(at);
    }
    
    private void ExecuteTask()
    {
      switch (CurrentTask)
      {
        case MoveToDestinationTask task:
          task.Completed = (task.Destination - _mover.transform.position).magnitude < 0.05f;
          break;

        case InteractWithBuildingTask task:
          if (NearBuilding == task.BuildingToInteract)
          {
            NearBuilding.Interact(gameObject);
            task.Completed = true;
          }
          break;

        default:
          throw new ArgumentOutOfRangeException();
      }
    }

    private void EndTask()
    {
      _mover.Stop();
      CurrentTask = null;
    }
  }
}