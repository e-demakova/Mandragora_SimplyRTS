using UnityEngine;
using UnityEngine.AI;

namespace Code.Logic.Bots
{
  public class BotMover : MonoBehaviour
  {
    [SerializeField]
    private NavMeshAgent Agent;

    public void Move(Vector3 destination)
    {
      if(destination != Agent.destination)
        SetDestination(destination);
    }

    public void Stop()
    {
      Agent.SetDestination(transform.position);
    }

    private void SetDestination(Vector3 destination)
    {
      Agent.SetDestination(destination);
    }
  }
}