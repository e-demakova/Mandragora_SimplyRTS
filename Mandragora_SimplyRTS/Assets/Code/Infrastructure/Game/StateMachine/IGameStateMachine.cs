using Code.Infrastructure.Game.StateMachine.States;

namespace Code.Infrastructure.Game.StateMachine
{
  public interface IGameStateMachine
  {
    void ChangeState<TState>() where TState : IState;
  }
}