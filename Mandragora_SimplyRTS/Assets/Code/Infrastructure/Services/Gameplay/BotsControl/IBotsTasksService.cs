using System.Collections.Generic;
using Code.Logic.Bots;

namespace Code.Infrastructure.Services.Gameplay.BotsControl
{
  public interface IBotsTasksService : IService
  {
    List<BotTaskExecutor> SelectedBots { get; }

    void SubscribeOnBots();
    void Cleanup();
  }
}