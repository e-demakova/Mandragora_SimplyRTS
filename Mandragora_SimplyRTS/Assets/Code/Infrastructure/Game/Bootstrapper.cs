using Code.Extensions;
using Code.Infrastructure.Game.StateMachine;
using Code.Infrastructure.Services;
using Zenject;

namespace Code.Infrastructure.Game
{
  public class Bootstrapper : MonoInstaller<Bootstrapper>
  {
    public override void InstallBindings()
    {
      ServicesInstaller.Install(Container);
      StateMachineInstaller.Install(Container);
      
      Container.FullBind<Game>();
    }
  }
}