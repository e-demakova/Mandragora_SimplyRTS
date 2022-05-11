using System.Collections.Generic;
using Code.Infrastructure.Services.AssetsManagement;
using UnityEngine;

namespace Code.Infrastructure.Services.Factories
{
  public class BotsFactory : IBotsFactory
  {
    private readonly IAssetsProvider _assets;

    public List<GameObject> Bots { get; private set; } = new List<GameObject>();

    public BotsFactory(IAssetsProvider assets)
    {
      _assets = assets;
    }
    
    public void SpawnBot(GameObject spawner)
    {
      GameObject bot = _assets.Instantiate(AssetPath.Bot);
      bot.transform.position = spawner.transform.position;
      Bots.Add(bot);
    }
  }
}