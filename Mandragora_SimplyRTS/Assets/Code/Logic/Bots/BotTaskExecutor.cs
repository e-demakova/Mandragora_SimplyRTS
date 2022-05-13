using System;
using Code.Extensions;
using Code.Logic.Bots.Tasks;
using Code.Logic.Buildings;
using UnityEngine;

namespace Code.Logic.Bots
{
  public class BotTaskExecutor : MonoBehaviour
  {
    [SerializeField]
    private BotMover _mover;

    public Building NearBuilding { get; set; }

    public void ExecuteTask(ITask taskForExecute)
    {
      _mover.MoveAt(taskForExecute.Destination);
      
      switch (taskForExecute)
      {
        case MoveToDestinationTask task:
          ExecuteMoveTask(task);
          break;

        case InteractWithBuildingTask task:
          ExecuteInteractTask(task);
          break;

        default:
          throw new ArgumentOutOfRangeException();
      }
    }

    public void EndTask(ITask task)
    {
      _mover.Stop();
      task?.Kill();
    }
    
    private void ExecuteMoveTask(MoveToDestinationTask task)
    {
      bool destinationReached = _mover.transform.DestinationReached(task.Destination);

      if (destinationReached)
        task.Complete();
    }

    private void ExecuteInteractTask(InteractWithBuildingTask task)
    {
      if (NearBuilding != task.BuildingToInteract)
        return;

      NearBuilding.Interact(gameObject);
      task.Complete();
    }
  }
}