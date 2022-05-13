using Code.Logic.Bots.Tasks;
using Code.Logic.Buildings;
using UnityEngine;

namespace Code.Infrastructure.Services.Gameplay.BotsTasks
{
  public interface ITasksPool : IService
  {
    ITask GetTask(BotTaskExecutor bot, Vector3 at);
    ITask GetTask(BotTaskExecutor bot, Building building);
  }
}