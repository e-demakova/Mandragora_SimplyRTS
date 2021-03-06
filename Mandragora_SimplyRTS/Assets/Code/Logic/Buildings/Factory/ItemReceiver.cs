using System.Collections.Generic;
using UnityEngine;

namespace Code.Logic.Buildings.Factory
{
  public class ItemReceiver : MonoBehaviour
  {
    private readonly List<GameObject> _items = new List<GameObject>();

    public void PutItem(GameObject item)
    {
      _items.Add(item);
      item.transform.SetParent(transform);
      item.SetActive(false);
    }
  }
}