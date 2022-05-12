using UnityEngine;

namespace Code.Infrastructure.Services.Factories
{
  public interface IItemFactory : IService
  {
    GameObject CreateItem(Vector3 at);
  }
}