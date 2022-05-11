using System.Collections.Generic;
using Code.Infrastructure.Services.Factories;
using Code.Logic.Bots;
using UnityEngine;

namespace Code.Infrastructure.Services.Gameplay.BotsControl
{
  class BotsTasksService : IBotsTasksService
  {
    private readonly BotsFactory _factory;

    public List<GameObject> SelectedBots { get; private set; } = new List<GameObject>();

    public BotsTasksService(BotsFactory factory)
    {
      _factory = factory;
    }
    
    public void SubscribeOnBots()
    {
      foreach (GameObject bot in _factory.Bots)
      {
        BotSelector selector = bot.GetComponent<BotSelector>();
        selector.BotSelected += OnSelect;
        selector.BotDeselected += OnDeselect;
      }
    }

    public void Cleanup()
    {
      foreach (GameObject bot in _factory.Bots)
      {
        BotSelector selector = bot.GetComponent<BotSelector>();
        selector.BotSelected -= OnSelect;
        selector.BotDeselected -= OnDeselect;
      }
    }

    private void OnSelect(GameObject bot)
    {
      SelectedBots.Add(bot);
      Debug.Log(SelectedBots.Count);
    }

    private void OnDeselect(GameObject bot)
    {
      SelectedBots.Remove(bot);
      Debug.Log(SelectedBots.Count);
    }
  }
}