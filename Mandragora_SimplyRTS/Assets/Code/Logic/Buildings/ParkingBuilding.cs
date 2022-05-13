using Code.Infrastructure.Services.Factories;
using Code.Infrastructure.Services.Gameplay;
using UnityEngine;
using Zenject;

namespace Code.Logic.Buildings
{
  public class ParkingBuilding : Building
  {
    private IBotsFactory _botsFactory;
    private IAnxietyService _anxiety;
    
    private int _receivedBots;
    private bool _anxietyDeclared;

    [Inject]
    public void Constructor(IBotsFactory botsFactory, IAnxietyService anxiety)
    {
      _botsFactory = botsFactory;
      _anxiety = anxiety;

      _anxiety.Declared += OnAnxietyDeclared;
      _anxiety.Stopped += OnAnxietyStopped;
    }

    protected override void Cleanup()
    {
      _anxiety.Declared -= OnAnxietyDeclared;
      _anxiety.Stopped -= OnAnxietyStopped;
    }

    public override void Interact(GameObject bot)
    {
    }

    protected override void OnBotEnter(GameObject bot)
    {
      _receivedBots += 1;
      if(_anxietyDeclared && _receivedBots == _botsFactory.Bots.Count)
        CloseGates();
    }

    protected override void OnBotExit(GameObject bot)
    {
      _receivedBots -= 1;
    }

    private void OnAnxietyDeclared()
    {
      _anxietyDeclared = true;
    }

    private void OnAnxietyStopped()
    {
      _anxietyDeclared = false;
      OpenGates();
    }

    private void CloseGates()
    {
    }

    private void OpenGates()
    {
    }
  }
}