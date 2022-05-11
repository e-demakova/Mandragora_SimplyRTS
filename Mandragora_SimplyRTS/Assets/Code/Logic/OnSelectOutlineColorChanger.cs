using UnityEngine;

namespace Code.Logic
{
  [RequireComponent(typeof(Collider))]
  public class OnSelectOutlineColorChanger : MonoBehaviour
  {
    public Color DefaultOutline = Color.white;
    public Color OnSelectOutline = Color.magenta;
    
    [SerializeField]
    private Outline _outline;

    [SerializeField]
    private OnMouseEnterHighlighter _onMouseHighlighter;

    private bool _selected;
    
    private void Awake()
    {
      SetHighlighterDefaultColor(DefaultOutline);
      _outline.OutlineColor = DefaultOutline;
    }

    private void OnMouseUp()
    {
      _selected = !_selected;
      Color color = _selected ? OnSelectOutline : DefaultOutline;
      _outline.OutlineColor = color;

      SetHighlighterDefaultColor(color);
    }

    private void SetHighlighterDefaultColor(Color color)
    {
      if (_onMouseHighlighter != null)
        _onMouseHighlighter.DefaultOutline = color;
    }
  }
}