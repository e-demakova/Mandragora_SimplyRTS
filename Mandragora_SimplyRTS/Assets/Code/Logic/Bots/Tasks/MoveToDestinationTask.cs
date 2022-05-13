using System;
using Code.Pools;
using UnityEngine;

namespace Code.Logic.Bots.Tasks
{
  public class MoveToDestinationTask : ITask
  {
    public event Action<IPoolItem> LifeEnd;

    public bool Completed { get; private set; }
    public bool Killed { get; private set; }
    public Vector3 Destination { get; set; }

    public void Dispose()
    {
      Destination = Vector3.zero;
      Completed = false;
    }

    public void Complete()
    {
      Completed = true;
    }

    public void RefreshTask()
    {
      Completed = false;
    }

    public void Refresh()
    {
      Killed = false;
    }

    public void Kill()
    {
      Killed = true;
      LifeEnd?.Invoke(this);
    }
  }
}