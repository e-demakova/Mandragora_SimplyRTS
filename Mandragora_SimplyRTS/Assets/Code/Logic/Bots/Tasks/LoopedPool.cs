using System.Collections.Generic;

namespace Code.Logic.Bots.Tasks
{
  public class LoopedPool<T> where T : class
  {
    private readonly List<T> _elements = new List<T>();
    private int _head;
    public int Count => _elements.Count;

    public T Pull()
    {
      if (_elements.Count == 0)
        return null;
      
      T element = _elements[_head];
      _head = (_head + 1) % _elements.Count;
      return element;
    }

    public void Push(T element)
    {
      _elements.Add(element);
    }

    public bool Contains(T element)
    {
      return _elements.Contains(element);
    }

    public void Clear()
    {
      _head = 0;
      _elements.Clear();
    }
  }
}