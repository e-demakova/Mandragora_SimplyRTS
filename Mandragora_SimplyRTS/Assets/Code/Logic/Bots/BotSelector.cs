using System;
using UnityEngine;

namespace Code.Logic.Bots
{
  [RequireComponent(typeof(Collider))]
  public class BotSelector : MonoBehaviour
  {
    public event Action<GameObject> BotSelected;
    public event Action<GameObject> BotDeselected;

    private bool _selected;

    public bool Selected => _selected;

    private void OnMouseUp()
    {
      _selected = !_selected;

      if (_selected)
        BotSelected?.Invoke(gameObject);
      else
        BotDeselected?.Invoke(gameObject);
    }
  }
}