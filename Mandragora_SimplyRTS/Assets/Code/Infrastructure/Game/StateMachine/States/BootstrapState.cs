using System;
using Code.Infrastructure.Services.Factories;
using UnityEngine;

namespace Code.Infrastructure.Game.StateMachine.States
{
  public class BootstrapState : IState
  {
    private const string BotSpawnerTag = "BotSpawner";
    
    private readonly IBotsFactory _botsFactory;

    public BootstrapState(IBotsFactory botsFactory)
    {
      _botsFactory = botsFactory;
    }

    public void Enter()
    {
      _botsFactory.Cleanup();
      InitBots();
    }

    private void InitBots()
    {
      GameObject.FindGameObjectsWithTag(BotSpawnerTag);
    }

  }
}