using Code.Logic.Bots;
using UnityEditor;
using UnityEngine;

namespace Code.Editor
{
  [CustomEditor(typeof(BotBaggage))]
  public class BotBaggageEditor : UnityEditor.Editor
  {
    [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.Selected)]
    public static void RenderCustomGizmo(BotBaggage target, GizmoType gizmo)
    {
      Gizmos.color = Color.red;
      Vector3 position = target.transform.TransformPoint(target.ItemPosition);
      Gizmos.DrawSphere(position, 0.5f);
    }
  }
}