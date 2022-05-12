using System.Collections.Generic;
using Code.Logic.Bots;
using Code.Logic.Bots.Tasks;

namespace Code.Infrastructure.Services.Gameplay.BotsControl
{
  public interface IBotsTasksService : IService
  {
    List<BotTaskExecutor> SelectedBots { get; }
    bool AllBotsDeselected();
    void SubscribeOnBots();
    void Cleanup();
  }
}