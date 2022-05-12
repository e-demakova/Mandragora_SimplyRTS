using Code.Infrastructure.Services.Factories;
using UnityEngine;
using Zenject;

namespace Code.Logic.Buildings.Storage
{
  public class ItemGiver : MonoBehaviour
  {
    public Vector3 ItemPosition;
    
    private GameObject _containedItem;
    private IItemFactory _itemFactory;

    [Inject]
    public void Constructor(IItemFactory itemFactory)
    {
      _itemFactory = itemFactory;
      CreateNewItem();
    }
    
    public GameObject GetItem()
    {
      GameObject item = _containedItem.gameObject;
      ReplaceGivenItem();

      return item;
    }

    private void ReplaceGivenItem()
    {
      CreateNewItem();
    }

    private void CreateNewItem()
    {
      Vector3 at = transform.TransformPoint(ItemPosition);
      _containedItem = _itemFactory.CreateItem(at);
      _containedItem.transform.parent = transform;
    }
  }
}