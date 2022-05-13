using Code.Constants;
using UnityEngine;

namespace Code.Extensions
{
  public static class MathExtensions
  {
    public static bool DestinationReached(this Transform transform, Vector3 destination)
    {
      Vector3 distance = destination - transform.position;
      bool distanceIsZero = distance.magnitude < MathConst.VectorEpsilon;
      
      return distanceIsZero;
    }
  }
}