using Code.Pools;
using UnityEngine;

namespace Code.Logic.Bots.Tasks
{
  public interface ITask : IPoolItem
  {
    bool Completed { get; }
    Vector3 Destination { get; set; }

    void Complete();
    void RefreshTask();
  }
}