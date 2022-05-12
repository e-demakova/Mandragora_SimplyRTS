using Code.Logic.Bots;
using UnityEngine;

namespace Code.Logic.Buildings.Factory
{
  public class FactoryBuilding : Building
  {
    [SerializeField]
    public ItemReceiver _ItemReceiver;

    public override void Interact(GameObject bot)
    {
      BotBaggage baggage = bot.GetComponent<BotBaggage>();

      if (baggage.CanGiveItem())
      {
        GameObject item = baggage.GetItem();
        _ItemReceiver.PutItem(item);
        
        Debug.Log($"ITEM [{item.name}] successfully received from the BOT [{bot.name}] by FACTORY [{gameObject.name}].");
      }
      else
      {
        Debug.Log($"BOT [{bot.name}] can't give the ITEM to the FACTORY [{gameObject.name}].");
      }
    }
  }
}