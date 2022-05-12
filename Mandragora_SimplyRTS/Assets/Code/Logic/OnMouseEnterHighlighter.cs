using StoreAssets.QuickOutline.Scripts;
using UnityEngine;

namespace Code.Logic
{
  [RequireComponent(typeof(Collider))]
  public class OnMouseEnterHighlighter : MonoBehaviour
  {
    public Color DefaultOutline = Color.white;
    public Color OnMouseOutline = Color.yellow;
    
    [SerializeField]
    private Outline _outline;

    private void Awake()
    {
      SetOutlineColor(DefaultOutline);
    }

    private void OnMouseEnter()
    {
      SetOutlineColor(OnMouseOutline);
    }

    private void OnMouseExit()
    {
      SetOutlineColor(DefaultOutline);
    }

    private void SetOutlineColor(Color color)
    {
      _outline.OutlineColor = color;
    }
  }
}