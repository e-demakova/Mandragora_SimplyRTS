using Zenject;

namespace Code.Extensions
{
  public static class ZenjectExtensions
  {
    public static void FullBind<T>(this DiContainer container)
    {
      container.BindInterfacesAndSelfTo<T>().AsSingle().NonLazy();
    }
  }
}