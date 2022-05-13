using Code.Logic.Bots.Tasks;
using Code.Logic.Buildings;
using UnityEngine;

namespace Code.Infrastructure.Services.Gameplay.BotsTasks
{
  public interface ITasksPool : IService
  {
    ITask GetTask(Transform bot, Vector3 at);
    ITask GetTask(Transform bot, Building building);
  }
}