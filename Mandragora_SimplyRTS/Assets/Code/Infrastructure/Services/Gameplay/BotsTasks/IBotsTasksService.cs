using System.Collections.Generic;
using Code.Logic.Bots;
using Code.Logic.Buildings;

namespace Code.Infrastructure.Services.Gameplay.BotsTasks
{
  public interface IBotsTasksService : IService
  {
    List<BotTaskDistributor> SelectedBots { get; }
    
    bool AllBotsDeselected();
    void SetUrgentTaskForAll(Building building);
    void SendAllToNormalTasksExecution();
  }
}