using System;

namespace Code.Pools
{
  public interface IPoolItem
  {
    event Action<IPoolItem> LifeEnd;
    void Refresh();
    void Kill();
  }
}