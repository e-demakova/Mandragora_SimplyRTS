namespace Code.Pools
{
  public interface IPool<T>where T : IPoolItem
  {
    T Pull();
  }
}