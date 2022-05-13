using System;
using Code.Constants;
using Code.Extensions;
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
    public Vector3 MouseMapPosition { get; private set; }
    public Vector3 MouseScreenPosition { get; private set; }
    public Collider MouseOverlayCollider { get; private set; }
    public bool HoldShift => Input.GetKey(KeyCode.LeftShift);

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

    public bool MouseOnWalkableGround()
    {
      return MouseOverlayCollider.CompareTag(Tags.WalkableGround);
    }

    public bool MouseOnGround()
    {
      return MouseOverlayCollider.CompareLayer(Layers.Ground);
    }

    public bool MouseOnBuilding()
    {
      return MouseOverlayCollider.CompareLayer(Layers.Building);
    }

    public bool MouseOnBot()
    {
      return MouseOverlayCollider.CompareLayer(Layers.Bot);
    }

    private void UpdateMousePosition()
    {
      MouseScreenPosition = Input.mousePosition;
      MouseMapPosition = CalculateMouseGroundPosition(out RaycastHit hit);
      MouseOverlayCollider = hit.collider;
    }

    private Vector3 CalculateMouseGroundPosition(out RaycastHit hit)
    {
      Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

      Physics.Raycast(ray, out hit, _camera.farClipPlane, Layers.Ground | Layers.Building | Layers.Bot);
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