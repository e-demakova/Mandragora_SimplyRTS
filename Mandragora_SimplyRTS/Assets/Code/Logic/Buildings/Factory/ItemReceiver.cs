using System.Collections.Generic;
using UnityEngine;

namespace Code.Logic.Buildings.Factory
{
  public class ItemReceiver : MonoBehaviour
  {
    private List<GameObject> _items = new List<GameObject>();

    public void PutItem(GameObject item)
    {
      _items.Add(item);
    }
  }
}