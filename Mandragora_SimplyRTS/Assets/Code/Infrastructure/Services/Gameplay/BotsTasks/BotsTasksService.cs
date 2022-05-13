using System.Collections.Generic;
using Code.Infrastructure.Services.Factories;
using Code.Infrastructure.Services.PlayerInput;
using Code.Logic.Bots;
using Code.Logic.Bots.Tasks;
using Code.Logic.Buildings;
using UnityEngine;

namespace Code.Infrastructure.Services.Gameplay.BotsTasks
{
  class BotsTasksService : IBotsTasksService
  {
    private readonly IInputService _input;
    private readonly ITasksPool _tasksPool;
    private readonly IBotsFactory _botsFactory;

    public List<BotTaskDistributor> SelectedBots { get; } = new List<BotTaskDistributor>();

    public BotsTasksService(IInputService input, ITasksPool tasksPool, IBotsFactory botsFactory)
    {
      _input = input;
      _tasksPool = tasksPool;
      _botsFactory = botsFactory;

      SelectedBots.Capacity = _botsFactory.Bots.Count;
      _input.RightClick += OnRightClick;
      _input.LeftClick += OnLeftClick;
    }

    public bool AllBotsDeselected()
    {
      return SelectedBots.Count == 0;
    }

    public void SetUrgentTaskForAll(Building building)
    {
      foreach (GameObject bot in _botsFactory.Bots)
      {
        BotTaskDistributor taskExecutor = bot.GetComponent<BotTaskDistributor>();
        taskExecutor.SetUrgentTask(_tasksPool.GetTask(taskExecutor.transform, building));
      }
    }

    public void SendAllToNormalTasksExecution()
    {
      foreach (GameObject bot in _botsFactory.Bots)
      {
        BotTaskDistributor taskExecutor = bot.GetComponent<BotTaskDistributor>();
        taskExecutor.EndUrgentTask();
      }
    }

    private void OnLeftClick()
    {
      if (!_input.MouseOnBot())
        return;

      GameObject overlapBot = _input.MouseOverlayCollider.gameObject;
      BotTaskDistributor botTaskExecutor = overlapBot.GetComponent<BotTaskDistributor>();

      if (SelectedBots.Contains(botTaskExecutor))
        DeselectBot(botTaskExecutor, overlapBot);

      else
        SelectBot(botTaskExecutor, overlapBot);
    }

    private void OnRightClick()
    {
      if (_input.MouseOnWalkableGround())
        GiveMoveTasks();

      if (_input.MouseOnBuilding())
        GiveBuildingInteractionTask();
    }

    private void SelectBot(BotTaskDistributor taskExecutor, GameObject overlapBot)
    {
      if (!_input.HoldShift)
        DeselectAllBots();

      SelectedBots.Add(taskExecutor);
      SelectBot(overlapBot);
    }

    private void DeselectBot(BotTaskDistributor taskExecutor, GameObject overlapBot)
    {
      DeselectBot(overlapBot);
      SelectedBots.Remove(taskExecutor);
    }

    private void DeselectAllBots()
    {
      foreach (BotTaskDistributor bot in SelectedBots)
        DeselectBot(bot.gameObject);

      SelectedBots.Clear();
    }

    private void SelectBot(GameObject bot)
    {
      bot.GetComponent<BotSelectionView>().Select();
    }

    private void DeselectBot(GameObject bot)
    {
      bot.GetComponent<BotSelectionView>().Deselect();
    }

    private void GiveMoveTasks()
    {
      foreach (BotTaskDistributor bot in SelectedBots)
      {
        ITask task = _tasksPool.GetTask(bot.transform, _input.MouseMapPosition);
        SetTask(bot, task);
      }
    }

    private void GiveBuildingInteractionTask()
    {
      Building building = _input.MouseOverlayCollider.GetComponent<Building>();

      foreach (BotTaskDistributor bot in SelectedBots)
      {
        ITask task = _tasksPool.GetTask(bot.transform, building);
        SetTask(bot, task);
      }
    }

    private void SetTask(BotTaskDistributor bot, ITask task)
    {
      if (_input.HoldShift)
      {
        bot.SetTaskToPool(task);
        if(bot.CurrentTask == null)
          bot.SetTaskFromPool();
      }
      else
      {
        bot.SetTask(task);
        bot.ClearTaskPool();
      }
    }
  }
}