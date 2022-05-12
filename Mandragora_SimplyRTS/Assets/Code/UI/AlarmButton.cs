using System;
using Code.Infrastructure.Services.Gameplay.BotsControl;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UI
{
  public class AlarmButton : MonoBehaviour
  {
    private const string AlarmText = "Тревога";
    private const string StopAlarmText = "Отбой";

    [SerializeField]
    private Button _button;

    [SerializeField]
    private TextMeshProUGUI _text;

    private IBotsTasksService _botsTasks;
    
    private bool _alarm;
    private Color _alarmColor = Color.red;
    private Color _stopAlarmColor = Color.blue;

    [Inject]
    public void Constructor(IBotsTasksService botsTasks)
    {
      _botsTasks = botsTasks;
    }
    
    private void Awake()
    {
      _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
      _button.image.color = _alarm ? _alarmColor : _stopAlarmColor;
      _text.text = _alarm ? AlarmText : StopAlarmText;
      _alarm = !_alarm;

      if (_alarm)
        _botsTasks.Alarm();
      else
        _botsTasks.StopAlarm();
    }
  }
}