using System;
using System.Collections.Generic;
using Code.Infrastructure.Game.StateMachine.States;

namespace Code.Infrastructure.Game.StateMachine
{
  public class GameStateMachine : IGameStateMachine
  {
    private Dictionary<Type, IState> _states;
    private IState _activeState;

    public void Init(BootstrapState bootstrap, GameLoopState gameLoop)
    {
      _states = new Dictionary<Type, IState>()
      {
        [typeof(BootstrapState)] = bootstrap,
        [typeof(GameLoopState)] = gameLoop,
      };
    }

    public void ChangeState<TState>() where TState : IState
    {
      _activeState?.Exit();

      _activeState = GetState<TState>();
      _activeState.Enter();
    }

    private IState GetState<TState>() where TState : IState
    {
      return _states[typeof(TState)];
    }
  }
}