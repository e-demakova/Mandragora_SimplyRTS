using UnityEngine;

namespace Code.Infrastructure.Services.AssetsManagement
{
  public interface IAssetsProvider : IService
  {
    GameObject Instantiate(string path);
  }
}