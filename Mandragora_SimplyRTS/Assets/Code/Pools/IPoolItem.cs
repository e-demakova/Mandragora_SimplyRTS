using System;

namespace Code.Pools
{
  public interface IPoolItem : IDisposable
  {
    event Action<IPoolItem> LifeEnd;
    bool Killed { get; }
    void Refresh();
    void Kill();
  }
}