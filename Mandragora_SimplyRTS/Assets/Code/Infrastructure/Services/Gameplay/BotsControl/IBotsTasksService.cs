using System.Collections.Generic;
using UnityEngine;

namespace Code.Infrastructure.Services.Gameplay.BotsControl
{
  public interface IBotsTasksService : IService
  {
    List<GameObject> SelectedBots { get; }

    void SubscribeOnBots();
    void Cleanup();
  }
}