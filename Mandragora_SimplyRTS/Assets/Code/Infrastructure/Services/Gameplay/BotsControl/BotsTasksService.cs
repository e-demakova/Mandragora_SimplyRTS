using System.Collections.Generic;
using Code.Infrastructure.Services.Factories;
using Code.Infrastructure.Services.PlayerInput;
using Code.Logic.Bots;
using UnityEngine;

namespace Code.Infrastructure.Services.Gameplay.BotsControl
{
  class BotsTasksService : IBotsTasksService
  {
    private readonly BotsFactory _factory;
    private readonly IInputService _input;

    public List<BotTaskExecutor> SelectedBots { get; } = new List<BotTaskExecutor>();

    public BotsTasksService(BotsFactory factory, IInputService input)
    {
      _factory = factory;
      _input = input;
      _input.RightClick += OnRightClick;
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
      SelectedBots.Add(bot.GetComponent<BotTaskExecutor>());
    }

    private void OnDeselect(GameObject bot)
    {
      SelectedBots.Remove(bot.GetComponent<BotTaskExecutor>());
    }

    private void OnRightClick()
    {
      foreach (BotTaskExecutor bot in SelectedBots)
        bot.SetMoveToPositionTask(_input.MouseGroundPosition);
    }
  }
}