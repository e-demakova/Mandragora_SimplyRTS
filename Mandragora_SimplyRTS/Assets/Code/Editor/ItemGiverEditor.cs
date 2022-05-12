using Code.Logic.Buildings.Storage;
using UnityEditor;
using UnityEngine;

namespace Code.Editor
{
  [CustomEditor(typeof(ItemGiver))]
  public class ItemGiverEditor : UnityEditor.Editor
  {
    [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.Selected)]
    public static void RenderCustomGizmo(ItemGiver target, GizmoType gizmo)
    {
      Gizmos.color = Color.red;
      Vector3 position = target.transform.TransformPoint(target.ItemPosition);
      Gizmos.DrawSphere(position, 0.5f);
    }
  }
}