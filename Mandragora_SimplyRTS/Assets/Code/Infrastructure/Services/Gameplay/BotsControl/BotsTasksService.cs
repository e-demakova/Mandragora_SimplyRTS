using System.Collections.Generic;
using UnityEngine;

namespace Code.Infrastructure.Services.Gameplay.BotsControl
{
  class BotsTasksService : IBotsTasksService
  {
    public List<GameObject> SelectedBots { get; private set; } = new List<GameObject>();

    public void SubscribeOnBots()
    {
      
    }
  }
}