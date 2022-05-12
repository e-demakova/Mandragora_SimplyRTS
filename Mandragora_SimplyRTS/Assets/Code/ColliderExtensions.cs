using UnityEngine;

namespace Code
{
  public static class ColliderExtensions
  {
    public static bool CompareLayer(this Collider collider, int layer)
    {
      return ((1 << collider.gameObject.layer) & layer) != 0;
    }
  }
}