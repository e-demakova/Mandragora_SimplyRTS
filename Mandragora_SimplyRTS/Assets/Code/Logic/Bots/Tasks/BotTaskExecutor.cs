using System;
using Code.Logic.Buildings;
using UnityEngine;

namespace Code.Logic.Bots.Tasks
{
  public class BotTaskExecutor : MonoBehaviour
  {
    private readonly LoopedPool<ITask> _tasksPool = new LoopedPool<ITask>();

    public ITask CurrentTask { get; private set; }
    public ITask UrgentTask { get; private set; }

    [SerializeField]
    private BotMover _mover;

    public Building NearBuilding { get; set; }

    private void FixedUpdate()
    {
      if (UrgentTask != null && !UrgentTask.Killed)
        ExecuteUrgentTask();
      else
        ExecuteTask();
    }

    public void SetTask(ITask task)
    {
      EndTask(CurrentTask);
      CurrentTask = task;
    }

    public void SetTaskFromPool()
    {
      CurrentTask = _tasksPool.Pull();
    }

    public void SetTaskToPool(ITask task)
    {
      if (CurrentTask != null && !_tasksPool.Contains(CurrentTask))
      {
        EndTask(CurrentTask);
        CurrentTask = null;
      }
        
      _tasksPool.Push(task);
    }

    public void ClearTaskPool()
    {
      _tasksPool.Clear();
    }

    public void SetUrgentTask(ITask task)
    {
      UrgentTask = task;
    }

    public void EndUrgentTask()
    {
      UrgentTask.Kill();
      UrgentTask = null;
    }

    private void ExecuteUrgentTask()
    {
      if (!UrgentTask.Completed)
        ExecuteTask(UrgentTask);
    }

    private void ExecuteTask()
    {
      if (CurrentTask == null || !CurrentTask.Executable())
        return;

      ExecuteTask(CurrentTask);

      if (CurrentTask.Completed)
        OnCurrentTaskComplete();
    }

    private void OnCurrentTaskComplete()
    {
      if (_tasksPool.Count == 0)
      {
        EndTask(CurrentTask);
        CurrentTask = null;
      }
      else
      {
        CurrentTask.RefreshTask();
        SetTaskFromPool();
      }
    }

    private void ExecuteTask(ITask taskForExecute)
    {
      _mover.Move(taskForExecute.Destination);
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

    private void ExecuteMoveTask(MoveToDestinationTask task)
    {
      bool destinationReached = (task.Destination - _mover.transform.position).magnitude < MathConst.VectorEpsilon;

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

    private void EndTask(ITask task)
    {
      _mover.Stop();
      task?.Kill();
    }
  }
}