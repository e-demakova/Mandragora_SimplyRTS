using System;
using System.ComponentModel;
using Code.Infrastructure.Services.Gameplay.BotsTasks;
using Code.Logic.Buildings;
using UnityEngine;

namespace Code.Infrastructure.Services.Gameplay
{
  public class AnxietyService : IAnxietyService
  {
    public event Action Declared;
    public event Action Stopped;

    private readonly IBotsTasksService _botTask;
    private readonly ParkingBuilding _parking;

    public AnxietyService(IBotsTasksService botTask)
    {
      _botTask = botTask;
      _parking = FindParking();
    }


    public void DeclareAnxiety()
    {
      _botTask.SetUrgentTaskForAll(_parking);
      Declared?.Invoke();
    }

    public void StopAnxiety()
    {
      _botTask.SendAllToNormalTasksExecution();
      Stopped?.Invoke();
    }

    private static ParkingBuilding FindParking()
    {
      GameObject[] parkings = GameObject.FindGameObjectsWithTag(Tags.Parking);
      
      if (parkings.Length > 1)
        throw new WarningException("There's more than one parking lot on scene.");
      
      return parkings[0].GetComponent<ParkingBuilding>();
    }
  }
}