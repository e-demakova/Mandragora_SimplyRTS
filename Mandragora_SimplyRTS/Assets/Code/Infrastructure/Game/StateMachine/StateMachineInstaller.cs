using Code.Infrastructure.Game.StateMachine.States;
using Zenject;

namespace Code.Infrastructure.Game.StateMachine
{
  public class StateMachineInstaller : Installer<StateMachineInstaller>
  {
    public override void InstallBindings()
    {
      Container.FullBind<GameStateMachine>();
      
      Container.FullBind<BootstrapState>();
      Container.FullBind<GameLoopState>();
    }
  }
}