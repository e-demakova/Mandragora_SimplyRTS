using System.Collections.Generic;
using Code.Logic.Bots.Tasks;
using Code.Logic.Buildings;

namespace Code.Infrastructure.Services.Gameplay.BotsTasks
{
  public interface IBotsTasksService : IService
  {
    List<BotTaskExecutor> SelectedBots { get; }
    
    bool AllBotsDeselected();
    void SetUrgentTaskForAll(Building building);
    void SendAllToNormalTasksExecution();
  }
}