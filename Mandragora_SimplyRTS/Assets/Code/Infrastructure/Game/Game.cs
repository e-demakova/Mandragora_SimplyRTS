using Code.Infrastructure.Game.StateMachine;
using Code.Infrastructure.Game.StateMachine.States;
using Zenject;

namespace Code.Infrastructure.Game
{
  public class Game : IInitializable
  {
    public GameStateMachine StateMachine;

    public Game(GameStateMachine stateMachine, BootstrapState bootstrap, GameLoopState gameLoop)
    {
      StateMachine = stateMachine;
      StateMachine.Init(bootstrap, gameLoop);
    }

    public void Initialize()
    {
      Start();
    }

    private void Start()
    {
      StateMachine.ChangeState<BootstrapState>();
    }
  }
}