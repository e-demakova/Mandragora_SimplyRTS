using UnityEngine;
using UnityEngine.AI;

namespace Code.Logic.Bots
{
  public class BotMove : MonoBehaviour
  {
    [SerializeField]
    private NavMeshAgent Agent;

    public void SetDestination(Vector3 destination)
    {
      Agent.destination = destination;
    }
  }
}