using System;
using UnityEngine;

namespace Code.Infrastructure.Services.PlayerInput
{
  public interface IInputService : IService
  {
    event Action LeftClick; 
    event Action RightClick;
    
    bool Blocked { get; set; }
    Vector3 MouseMapPosition { get; }
    Vector3 MouseScreenPosition { get; }
    Collider MouseOverlayCollider { get; }
    bool HoldShift { get; }
    void SetCamera(Camera camera);
    bool MouseOnWalkableGround();
    bool MouseOnGround();
    bool MouseOnBuilding();
    bool MouseOnBot();
  }
}