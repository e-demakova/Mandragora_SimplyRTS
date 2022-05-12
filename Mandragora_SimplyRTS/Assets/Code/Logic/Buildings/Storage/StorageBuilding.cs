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
      {
        GameObject item = _itemGiver.GetItem();
        baggage.GiveItem(item);
        Debug.Log($"ITEM [{item.name}] successfully received from the STORAGE [{gameObject.name}] by BOT [{bot.name}].");
      }
      else
      {
        Debug.Log($"BOT [{bot.name}] can't receive the ITEM from the STORAGE.");
      }
    }
  }
}