using Code.Logic.Bots;
using UnityEngine;

namespace Code.Logic.Buildings.Storage
{
  public class StorageBuilding : Building
  {
    [SerializeField]
    private ItemGiver _itemGiver;
    
    public override void Interact(GameObject bot)
    {
      BotBaggage baggage = bot.GetComponent<BotBaggage>();
      if (baggage.CanReceiveItem())
        baggage.GiveItem(_itemGiver.GetItem());
    }
  }
}