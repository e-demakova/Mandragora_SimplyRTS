using Code.Infrastructure.Services.Factories;
using Code.Infrastructure.Services.PlayerInput;
using UnityEngine;

namespace Code.Infrastructure.Game.StateMachine.States
{
  public class BootstrapState : IState
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly IBotsFactory _botsFactory;
    private readonly IInputService _input;

    public BootstrapState(IGameStateMachine stateMachine, IBotsFactory botsFactory, IInputService input)
    {
      _stateMachine = stateMachine;
      _botsFactory = botsFactory;
      _input = input;
    }

    public void Enter()
    {
      InitBots();
      InitInput();
      _stateMachine.ChangeState<GameLoopState>();
    }

    private void InitInput()
    {
      _input.SetCamera(Camera.main);
    }

    public void Exit()
    {
    }

    private void InitBots()
    {
      foreach (GameObject spawner in GameObject.FindGameObjectsWithTag(Tags.BotSpawner)) 
        _botsFactory.SpawnBot(spawner);

      _stateMachine.ChangeState<GameLoopState>();
    }
  }
}