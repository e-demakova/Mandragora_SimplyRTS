using UnityEngine;

namespace Code.Logic.Bots
{
  public class BotBaggage : MonoBehaviour
  {
    private GameObject _item;

    public bool CanReceiveItem()
    {
      return _item == null;
    }

    public bool CanPutItem()
    {
      return _item != null;
    }

    public void GiveItem(GameObject item)
    {
      _item = item;
    }

    public GameObject GetItem()
    {
      GameObject item = _item;
      _item = null;
      return item;
    }
  }
}