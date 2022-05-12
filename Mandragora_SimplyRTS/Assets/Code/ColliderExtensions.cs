using UnityEngine;

namespace Code
{
  public static class ColliderExtensions
  {
    public static bool IsWalkableGround(this Collider collider)
    {
      return collider.CompareTag(Tags.WalkableGround);
    }
  }
}