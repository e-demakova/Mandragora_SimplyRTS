using System.ComponentModel;
using Code.Infrastructure.Services.Gameplay.BotsTasks;
using Code.Logic.Buildings;
using UnityEngine;

namespace Code.Infrastructure.Services.Gameplay
{
  public class AnxietyLevelsService : IAnxietyLevelsService
  {
    private readonly IBotsTasksService _botTask;
    private readonly ParkingBuilding _parking;

    public AnxietyLevelsService(IBotsTasksService botTask)
    {
      _botTask = botTask;
      _parking = FindParking();
    }

    public void DeclareAnxiety()
    {
      _botTask.SetUrgentTaskForAll(_parking);
    }

    public void StopAnxiety()
    {
      _botTask.SendAllToNormalTasksExecution();
    }

    private static ParkingBuilding FindParking()
    {
      GameObject[] parkings = GameObject.FindGameObjectsWithTag(Tags.Parking);
      
      if (parkings.Length > 1)
        throw new WarningException("There's more than one parking lot on stage.");
      
      return parkings[0].GetComponent<ParkingBuilding>();
    }
  }
}