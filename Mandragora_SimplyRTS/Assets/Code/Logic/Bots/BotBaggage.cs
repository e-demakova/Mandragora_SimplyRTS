using UnityEngine;

namespace Code.Logic.Bots
{
  public class BotBaggage : MonoBehaviour
  {
    public Vector3 ItemPosition; 
    
    private GameObject _item;

    public bool CanReceiveItem()
    {
      return _item == null;
    }

    public bool CanGiveItem()
    {
      return _item != null;
    }

    public void ReceiveItem(GameObject item)
    {
      _item = item;
      _item.transform.position = transform.TransformPoint(ItemPosition);
      _item.transform.SetParent(transform);
    }

    public GameObject GetItem()
    {
      GameObject item = _item;
      _item = null;
      
      return item;
    }
  }
}