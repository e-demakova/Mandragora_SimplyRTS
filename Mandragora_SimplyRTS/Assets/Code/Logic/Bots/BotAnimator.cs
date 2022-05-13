using UnityEngine;
using UnityEngine.AI;

namespace Code.Logic.Bots
{
  public class BotAnimator : MonoBehaviour
  {
    private readonly int _rideId = Animator.StringToHash("Ride");

    [SerializeField]
    private NavMeshAgent _agent;

    [SerializeField]
    private Animator _animator;
    
    private void Update()
    {
      bool ride = (_agent.destination - _agent.transform.position).magnitude > MathConst.VectorEpsilon;
      _animator.SetBool(_rideId, ride);
    }
  }
}