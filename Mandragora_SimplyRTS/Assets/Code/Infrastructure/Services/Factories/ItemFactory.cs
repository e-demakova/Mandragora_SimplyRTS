using Code.Infrastructure.Services.AssetsManagement;
using UnityEngine;

namespace Code.Infrastructure.Services.Factories
{
  public class ItemFactory : IItemFactory
  {
    private readonly IAssetsProvider _assets;

    public ItemFactory(IAssetsProvider assets)
    {
      _assets = assets;
    }

    public GameObject CreateItem(Vector3 at)
    {
      return _assets.Instantiate(AssetPath.Item, at);
    }
  }
}