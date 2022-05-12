using Code.Infrastructure.Services.Factories;
using UnityEngine;
using Zenject;

namespace Code.Logic.Buildings
{
  public class ParkingBuilding : Building
  {
    private IBotsFactory _botsFactory;

    [Inject]
    public void Constructor(IBotsFactory botsFactory)
    {
      _botsFactory = botsFactory;
    }
    
    public override void Interact(GameObject bot)
    {
      
    }
  }
}