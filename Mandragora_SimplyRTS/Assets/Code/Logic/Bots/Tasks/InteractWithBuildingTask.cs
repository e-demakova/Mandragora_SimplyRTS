using System;
using Code.Logic.Buildings;
using Code.Pools;
using UnityEngine;

namespace Code.Logic.Bots.Tasks
{
  public class InteractWithBuildingTask : ITask
  {
    public event Action<IPoolItem> LifeEnd;

    public Building BuildingToInteract;

    public bool Completed { get; private set; }
    public Vector3 Destination { get; set; }

    public void Refresh()
    {
      Destination = Vector3.zero;
      BuildingToInteract = null;
      Completed = false;
    }

    public void Complete()
    {
      Completed = true;
    }

    public void Kill()
    {
      LifeEnd?.Invoke(this);
    }
  }
}