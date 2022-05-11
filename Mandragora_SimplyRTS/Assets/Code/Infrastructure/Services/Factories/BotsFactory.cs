using System.Collections.Generic;
using Code.Infrastructure.Services.AssetsManagement;
using Code.Infrastructure.Services.PlayerInput;
using Code.Logic.Bots;
using UnityEngine;

namespace Code.Infrastructure.Services.Factories
{
  public class BotsFactory : IBotsFactory
  {
    private readonly IAssetsProvider _assets;
    private readonly IInputService _input;

    public List<GameObject> Bots { get; } = new List<GameObject>();

    public BotsFactory(IAssetsProvider assets, IInputService input)
    {
      _assets = assets;
      _input = input;
    }
    
    public void SpawnBot(GameObject spawner)
    {
      GameObject bot = _assets.Instantiate(AssetPath.Bot);
      InitBot(spawner, bot);
      Bots.Add(bot);
    }

    private void InitBot(GameObject spawner, GameObject bot)
    {
      bot.transform.position = spawner.transform.position;
      bot.GetComponent<BotSelector>().Construct(_input);
    }
  }
}