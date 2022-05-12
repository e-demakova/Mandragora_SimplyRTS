using Code.Infrastructure.Services.Factories;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace Code.Logic.Storage
{
  public class ItemGiver : MonoBehaviour
  {
    private GameObject _containedItem;
    private IItemFactory _itemFactory;

    [Inject]
    public void Constructor(IItemFactory itemFactory)
    {
      _itemFactory = itemFactory;
    }
    
    public GameObject GetItem()
    {
      GameObject itemForGive = _containedItem.gameObject;
      ReplaceGivenItem();

      return itemForGive;
    }

    private void ReplaceGivenItem()
    {
      _containedItem = _itemFactory.CreateItem();
    }
  }
}