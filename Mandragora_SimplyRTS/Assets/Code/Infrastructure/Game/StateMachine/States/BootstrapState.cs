using Code.Infrastructure.Services.Factories;
using Code.Infrastructure.Services.Gameplay.BotsControl;
using UnityEngine;

namespace Code.Infrastructure.Game.StateMachine.States
{
  public class BootstrapState : IState
  {
    private const string BotSpawnerTag = "BotSpawner";

    private readonly IGameStateMachine _stateMachine;
    private readonly IBotsFactory _botsFactory;
    private readonly IBotsTasksService _botsTasksService;

    public BootstrapState(IGameStateMachine stateMachine, IBotsFactory botsFactory, IBotsTasksService botsTasksService)
    {
      _stateMachine = stateMachine;
      _botsFactory = botsFactory;
      _botsTasksService = botsTasksService;
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
      foreach (GameObject spawner in GameObject.FindGameObjectsWithTag(BotSpawnerTag)) 
        _botsFactory.SpawnBot(spawner);

      _botsTasksService.SubscribeOnBots();
      _stateMachine.ChangeState<GameLoopState>();
    }
  }
}