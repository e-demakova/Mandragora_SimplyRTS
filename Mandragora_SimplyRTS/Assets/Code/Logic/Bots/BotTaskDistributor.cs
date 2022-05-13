using Code.Logic.Bots.Tasks;
using UnityEngine;

namespace Code.Logic.Bots
{
  public class BotTaskDistributor : MonoBehaviour
  {
    private readonly LoopedPool<ITask> _tasksPool = new LoopedPool<ITask>();

    public ITask CurrentTask { get; private set; }
    public ITask UrgentTask { get; private set; }

    [SerializeField]
    private BotTaskExecutor _executor;

    private void FixedUpdate()
    {
      if (UrgentTaskActual())
        ExecuteUrgentTask();
      else
        ExecuteTask();
    }

    public void SetTask(ITask task)
    {
      _executor.EndTask(CurrentTask);
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
        _executor.EndTask(CurrentTask);
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

    private bool UrgentTaskActual()
    {
      return UrgentTask != null && !UrgentTask.Killed;
    }

    private void ExecuteUrgentTask()
    {
      if (!UrgentTask.Completed)
        _executor.ExecuteTask(UrgentTask);
    }

    private void ExecuteTask()
    {
      if (CurrentTask == null || !CurrentTask.Executable())
        return;

      _executor.ExecuteTask(CurrentTask);

      if (CurrentTask.Completed)
        OnCurrentTaskComplete();
    }

    private void OnCurrentTaskComplete()
    {
      if (_tasksPool.Count == 0)
      {
        _executor.EndTask(CurrentTask);
        CurrentTask = null;
      }
      else
      {
        CurrentTask.RefreshTask();
        SetTaskFromPool();
      }
    }
  }
}