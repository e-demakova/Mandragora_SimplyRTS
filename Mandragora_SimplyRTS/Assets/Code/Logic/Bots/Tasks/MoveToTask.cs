using UnityEngine;

namespace Code.Logic.Bots.Tasks
{
  public class MoveToTask : ITask
  {
    public TaskType Type => TaskType.MoveTo;
    public Vector3 Destination;

    public MoveToTask(Vector3 destination)
    {
      Destination = destination;
    }
  }
}