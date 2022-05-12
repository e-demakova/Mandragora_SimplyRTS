using System;
using StoreAssets.QuickOutline.Scripts;
using UnityEngine;

namespace Code.Logic.Bots
{
  [RequireComponent(typeof(Collider))]
  public class BotSelectionView : MonoBehaviour
  {
    public Color DefaultOutline = Color.white;
    public Color OnSelectOutline = Color.cyan;
    
    [SerializeField]
    private Outline _outline;

    [SerializeField]
    private OnMouseEnterHighlighter _onMouseHighlighter;

    private void Awake()
    {
      SetOutlineColor(DefaultOutline);
    }

    public void Select()
    {
      SetOutlineColor(OnSelectOutline);
    }

    public void Deselect()
    {
      SetOutlineColor(DefaultOutline);
    }

    private void SetOutlineColor(Color color)
    {
      _outline.OutlineColor = color;
      _onMouseHighlighter.DefaultOutline = color;
    }
  }
}