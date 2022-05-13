namespace Code.Logic.Bots.Tasks
{
  public static class TaskExtensions
  {
    public static bool Executable(this ITask task)
    {
      return !task.Completed && !task.Killed;
    }
  }
}