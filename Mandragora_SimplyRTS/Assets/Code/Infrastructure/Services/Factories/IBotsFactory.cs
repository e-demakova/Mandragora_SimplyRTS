using System.Collections.Generic;
using UnityEngine;

namespace Code.Infrastructure.Services.Factories
{
  public interface IBotsFactory : IService
  {
    List<GameObject> Bots { get; }
    
    void SpawnBot(GameObject spawner);
  }
}