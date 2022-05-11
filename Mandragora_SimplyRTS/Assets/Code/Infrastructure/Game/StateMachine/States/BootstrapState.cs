using System;
using Code.Infrastructure.Services.Factories;
using UnityEngine;

namespace Code.Infrastructure.Game.StateMachine.States
{
  public class BootstrapState : IState
  {
    private const string BotSpawnerTag = "BotSpawner";

    private readonly IGameStateMachine _stateMachine;
    private readonly IBotsFactory _botsFactory;

    public BootstrapState(IGameStateMachine stateMachine, IBotsFactory botsFactory)
    {
      _stateMachine = stateMachine;
      _botsFactory = botsFactory;
    }

    public void Enter()
    {
      InitBots();
      _stateMachine.ChangeState<GameLoopState>();
    }

    public void Exit()
    {
    }

    private void InitBots()
    {
      GameObject.FindGameObjectsWithTag(BotSpawnerTag);
      _stateMachine.ChangeState<GameLoopState>();
    }

  }
}