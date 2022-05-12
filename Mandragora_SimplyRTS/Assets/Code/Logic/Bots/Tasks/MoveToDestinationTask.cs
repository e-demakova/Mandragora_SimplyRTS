using UnityEngine;

namespace Code.Logic.Bots.Tasks
{
  public class MoveToDestinationTask : ITask
  {
    public Vector3 Destination;

    public bool Completed { get; set; }

    public MoveToDestinationTask(Vector3 destination)
    {
      Destination = destination;
    }
  }
}