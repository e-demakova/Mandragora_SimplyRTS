using System.Collections.Generic;
using Code.Infrastructure.Services.PlayerInput;
using Code.Logic.Bots;
using Code.Logic.Bots.Tasks;
using Code.Logic.Buildings;
using UnityEngine;

namespace Code.Infrastructure.Services.Gameplay.BotsControl
{
  class BotsTasksService : IBotsTasksService
  {
    private readonly IInputService _input;
    private ITasksPool _tasksPool;

    public List<BotTaskExecutor> SelectedBots { get; } = new List<BotTaskExecutor>();

    public BotsTasksService(IInputService input, ITasksPool tasksPool)
    {
      _input = input;
      _tasksPool = tasksPool;
      
      _input.RightClick += OnRightClick;
      _input.LeftClick += OnLeftClick;
    }

    public bool AllBotsDeselected()
    {
      return SelectedBots.Count == 0;
    }

    public void Alarm()
    {
      Debug.Log("Alarm!");
    }

    public void StopAlarm()
    {
      Debug.Log("Stop Alarm");
    }

    private void OnLeftClick()
    {
      if (!_input.MouseOnBot())
        return;

      GameObject overlapBot = _input.MouseOverlayCollider.gameObject;
      BotTaskExecutor botTaskExecutor = overlapBot.GetComponent<BotTaskExecutor>();

      if (SelectedBots.Contains(botTaskExecutor))
        DeselectBot(overlapBot, botTaskExecutor);

      else
        SelectBot(botTaskExecutor, overlapBot);
    }

    private void SelectBot(BotTaskExecutor taskExecutor, GameObject overlapBot)
    {
      if (!_input.HoldShift)
        DeselectAllBots();

      SelectedBots.Add(taskExecutor);
      SelectBot(overlapBot);
    }

    private void DeselectBot(GameObject overlapBot, BotTaskExecutor taskExecutor)
    {
      DeselectBot(overlapBot);
      SelectedBots.Remove(taskExecutor);
    }

    private void DeselectAllBots()
    {
      foreach (BotTaskExecutor bot in SelectedBots)
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

    private void OnRightClick()
    {
      if (_input.MouseOnWalkableGround())
        GiveMoveTasks();

      if (_input.MouseOnBuilding())
        GiveBuildingInteractionTask();
    }

    private void GiveMoveTasks()
    {
      foreach (BotTaskExecutor bot in SelectedBots)
      {
        ITask task = _tasksPool.GetMoveToPositionTask(bot, _input.MouseMapPosition);
        bot.SetTask(task);
      }
    }

    private void GiveBuildingInteractionTask()
    {
      Building building = _input.MouseOverlayCollider.GetComponent<Building>();

      foreach (BotTaskExecutor bot in SelectedBots)
      {
        ITask task = _tasksPool.GetBuildingInteractionTask(bot, building);
        bot.SetTask(task);
      }
    }
  }
}