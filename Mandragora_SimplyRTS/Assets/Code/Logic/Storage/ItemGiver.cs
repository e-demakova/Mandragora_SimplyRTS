using Code.Infrastructure.Services.Factories;
using UnityEngine;
using Zenject;

namespace Code.Logic.Storage
{
  public class ItemGiver : MonoBehaviour
  {
    public Vector3 ItemPosition;
    public float ItemScale = 1;
    
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
      GameObject itemForGive = _containedItem.gameObject;
      ReplaceGivenItem();

      return itemForGive;
    }

    private void ReplaceGivenItem()
    {
      CreateNewItem();
    }

    private void CreateNewItem()
    {
      Vector3 at = transform.TransformPoint(ItemPosition);
      _containedItem = _itemFactory.CreateItem(at);
      _containedItem.transform.localScale = Vector3.one * ItemScale;
      _containedItem.transform.parent = transform;
    }
  }
}