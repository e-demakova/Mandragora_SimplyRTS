using System.Collections.Generic;
using UnityEngine;

namespace Code.Pools
{
  public class Pool<T> : IPool<T> where T : IPoolItem, new()
  {
    private readonly Queue<T> _queue = new Queue<T>();

    public T Pull()
    {
      return PoolEmpty() ? NewItem() : _queue.Dequeue();
    }

    private bool PoolEmpty()
    {
      return _queue.Count == 0;
    }

    private T NewItem()
    {
      T item = new T();
      item.LifeEnd += Push;
      return item;
    }

    private void Push(IPoolItem item)
    {
      item.Refresh();
      _queue.Enqueue((T) item);
    }
  }
}