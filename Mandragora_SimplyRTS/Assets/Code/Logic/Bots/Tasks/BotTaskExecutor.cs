using UnityEngine;

namespace Code.Logic.Bots.Tasks
{
  public class BotTaskExecutor : MonoBehaviour
  {
    public ITask CurrentTask;

    [SerializeField]
    private BotMover _mover;
    
    public void SetMoveToPositionTask(Vector3 at)
    {
      CurrentTask = new MoveToTask(at);
      
      at.y = transform.position.y;
      _mover.Move(at);
    }
  }
}