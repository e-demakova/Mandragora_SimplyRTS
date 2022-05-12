using UnityEngine;
using UnityEngine.AI;

namespace Code.Logic.Bots
{
  public class BotMover : MonoBehaviour
  {
    [SerializeField]
    private NavMeshAgent Agent;

    public void Stop()
    {
      Agent.SetDestination(transform.position);
    }
    
    public void Move(Vector3 destination)
    {
      Agent.SetDestination(destination);
    }
  }
}