using System;
using Code.Logic.Buildings;
using UnityEngine;

namespace Code.Logic.Bots.Tasks
{
  public class BotTaskExecutor : MonoBehaviour
  {
    public ITask CurrentTask { get; private set; }

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

    public void SetTask(ITask task)
    {
      EndTask();
      CurrentTask = task;
      _mover.Move(task.Destination);
    }

    private void ExecuteTask()
    {
      switch (CurrentTask)
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

    private void ExecuteMoveTask(MoveToDestinationTask task)
    {
      bool destinationReached = (task.Destination - _mover.transform.position).magnitude < 0.05f;
      
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

    private void EndTask()
    {
      if(CurrentTask == null)
        return;
      
      _mover.Stop();
      CurrentTask.Kill();
      CurrentTask = null;
    }
  }
}