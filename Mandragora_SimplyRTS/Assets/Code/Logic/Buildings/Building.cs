using System;
using Code.Logic.Bots.Tasks;
using UnityEngine;

namespace Code.Logic.Buildings
{
  public abstract class Building : MonoBehaviour
  {
    [SerializeField]
    protected TriggerListener TriggerListener;

    private void Awake()
    {
      TriggerListener.Enter += OnBotEnter;
      TriggerListener.Exit += OnBotExit;
    }

    private void OnDestroy()
    {
      TriggerListener.Enter -= OnBotEnter;
      TriggerListener.Exit -= OnBotExit;
    }

    public abstract void Interact(GameObject bot);

    private void OnBotEnter(Collider other)
    {
      if (!other.CompareLayer(Layers.Bot))
        return;

      GameObject bot = other.gameObject;
      bot.GetComponent<BotTaskExecutor>().InformBuildingProximity(this);
      OnBotEnter(bot);
    }

    private void OnBotExit(Collider other)
    {
      if (other.CompareLayer(Layers.Bot)) 
        OnBotExit(other.gameObject);
    }

    protected virtual void OnBotEnter(GameObject bot)
    {
    }

    protected virtual void OnBotExit(GameObject bot)
    {
    }
  }
}