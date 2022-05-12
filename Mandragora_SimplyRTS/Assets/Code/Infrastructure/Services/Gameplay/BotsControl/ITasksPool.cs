using Code.Logic.Bots.Tasks;
using Code.Logic.Buildings;
using UnityEngine;

namespace Code.Infrastructure.Services.Gameplay.BotsControl
{
  public interface ITasksPool : IService
  {
    ITask GetMoveToPositionTask(BotTaskExecutor bot, Vector3 at);
    ITask GetBuildingInteractionTask(BotTaskExecutor bot, Building building);
  }
}