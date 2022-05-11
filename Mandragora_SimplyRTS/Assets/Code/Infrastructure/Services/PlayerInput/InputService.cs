using System;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Services.PlayerInput
{
  class InputService : IInputService, ITickable, IFixedTickable
  {
    public event Action LeftClick;
    public event Action RightClick;

    private Camera _camera;

    public bool Blocked { get; set; }
    public Vector3 MouseGroundPosition { get; private set; }
    public Vector3 MouseScreenPosition { get; private set; }

    public void Tick()
    {
      if (Blocked)
        return;

      if (Input.GetKeyUp(KeyCode.Mouse0))
        OnLeftClick();

      if (Input.GetKeyUp(KeyCode.Mouse1))
        OnRightClick();
    }

    public void FixedTick()
    {
      if (Blocked)
        return;

      UpdateMousePosition();
    }

    public void SetCamera(Camera camera)
    {
      _camera = camera;
    }

    private void UpdateMousePosition()
    {
      MouseScreenPosition = Input.mousePosition;
      MouseGroundPosition = CalculateMouseGroundPosition();
    }

    private Vector3 CalculateMouseGroundPosition()
    {
      Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

      Physics.Raycast(ray, out RaycastHit hit, _camera.farClipPlane, LayerMasks.Ground);
      return hit.point;
    }

    private void OnLeftClick()
    {
      LeftClick?.Invoke();
    }

    private void OnRightClick()
    {
      RightClick?.Invoke();
    }
  }
}