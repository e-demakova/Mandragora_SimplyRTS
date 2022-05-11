using UnityEngine;

namespace Code.Logic.Bots
{
  public class BotTaskExecutor : MonoBehaviour
  {
    [SerializeField]
    private BotMover _mover;
    
    public void SetMoveToPositionTask(Vector3 at)
    {
      at.y = transform.position.y;
      _mover.SetDestination(at);
    }
  }
}