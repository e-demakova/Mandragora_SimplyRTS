namespace Code.Infrastructure.Game.StateMachine.States
{
  public class GameLoopState : IState
  {
    private readonly IGameStateMachine _stateMachine;

    public GameLoopState(IGameStateMachine stateMachine)
    {
      _stateMachine = stateMachine;
    }

    public void Enter()
    {
    }

    public void Exit()
    {
    }
  }
}