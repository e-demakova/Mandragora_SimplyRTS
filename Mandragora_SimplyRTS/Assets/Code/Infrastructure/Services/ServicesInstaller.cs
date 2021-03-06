using Code.Extensions;
using Code.Infrastructure.Services.AssetsManagement;
using Code.Infrastructure.Services.Factories;
using Code.Infrastructure.Services.Gameplay;
using Code.Infrastructure.Services.Gameplay.BotsTasks;
using Code.Infrastructure.Services.PlayerInput;
using Zenject;

namespace Code.Infrastructure.Services
{
  public class ServicesInstaller : Installer<ServicesInstaller>
  {
    public override void InstallBindings()
    {
      Container.FullBind<AssetsProvider>();
      Container.FullBind<BotsFactory>();
      Container.FullBind<ItemFactory>();
      Container.FullBind<InputService>();
      Container.FullBind<BotsTasksService>();
      Container.FullBind<TasksPool>();
      Container.FullBind<AnxietyService>();
    }
  }
}