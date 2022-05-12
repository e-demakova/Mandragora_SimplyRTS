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
        _ItemReceiver.PutItem(baggage.GetItem());
      else
        Debug.Log($"BOT [{bot.name}] can't give the ITEM to the FACTORY [{gameObject.name}].");
    }
  }
}