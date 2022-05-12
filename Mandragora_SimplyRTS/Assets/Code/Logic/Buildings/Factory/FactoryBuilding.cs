using Code.Logic.Bots;
using Code.Logic.Bots.Tasks;
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

      if (baggage.CanPutItem())
        _ItemReceiver.PutItem(baggage.GetItem());
    }
  }
}