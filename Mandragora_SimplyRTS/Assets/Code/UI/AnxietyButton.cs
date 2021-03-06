using Code.Infrastructure.Services.Gameplay;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UI
{
  public class AnxietyButton : MonoBehaviour
  {
    private const string AnxietyText = "Тревога";
    private const string StopAnxietyText = "Отбой";

    private readonly Color _anxietyColor = Color.red;
    private readonly Color _anxietyAlarmColor = Color.blue;
    
    [SerializeField]
    private Button _button;

    [SerializeField]
    private TextMeshProUGUI _text;

    private IAnxietyService _anxiety;
    private bool _anxietyDeclared;

    [Inject]
    public void Constructor(IAnxietyService botsTasks)
    {
      _anxiety = botsTasks;
    }
    
    private void Awake()
    {
      _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
      _button.image.color = _anxietyDeclared ? _anxietyColor : _anxietyAlarmColor;
      _text.text = _anxietyDeclared ? AnxietyText : StopAnxietyText;
      _anxietyDeclared = !_anxietyDeclared;

      if (_anxietyDeclared)
        _anxiety.DeclareAnxiety();
      else
        _anxiety.StopAnxiety();
    }
  }
}