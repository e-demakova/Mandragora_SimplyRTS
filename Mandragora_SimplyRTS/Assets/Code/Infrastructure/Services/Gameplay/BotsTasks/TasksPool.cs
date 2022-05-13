using Code.Logic.Bots.Tasks;
using Code.Logic.Buildings;
using Code.Pools;
using UnityEngine;

namespace Code.Infrastructure.Services.Gameplay.BotsTasks
{
  public class TasksPool : ITasksPool
  {
    private readonly IPool<MoveToDestinationTask> _moveTasks = new Pool<MoveToDestinationTask>();
    private readonly IPool<InteractWithBuildingTask> _interactTask = new Pool<InteractWithBuildingTask>();

    public ITask GetTask(Transform bot, Vector3 at)
    {
      at.y = bot.position.y;
      MoveToDestinationTask task = _moveTasks.Pull();
      task.Destination = at;
      
      return task;
    }

    public ITask GetTask(Transform bot, Building building)
    {
      Vector3 destination = building.transform.position;
      destination.y = bot.position.y;
      InteractWithBuildingTask task = _interactTask.Pull();
      
      task.BuildingToInteract = building;
      task.Destination = destination;
      
      return task;
    }
  }
}