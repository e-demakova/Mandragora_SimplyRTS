using System;
using Code.Infrastructure.Services.PlayerInput;
using UnityEngine;

namespace Code.Logic.Bots
{
  [RequireComponent(typeof(Collider))]
  public class BotSelector : MonoBehaviour
  {
    public event Action<GameObject> BotSelected;
    public event Action<GameObject> BotDeselected;

    private IInputService _input;
    private bool _selected;

    public bool Selected => _selected;

    public void Construct(IInputService input)
    {
      _input = input;
    }

    private void OnMouseUp()
    {
      if(_input.Blocked)
        return;
      
      _selected = !_selected;

      if (_selected)
        BotSelected?.Invoke(gameObject);
      else
        BotDeselected?.Invoke(gameObject);
    }
  }
}