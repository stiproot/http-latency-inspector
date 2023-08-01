namespace HttpLatencyInspector.Factories;

public class TimedTaskFactory
{
  public static TimedTask Create(Func<Task<HttpResponseMessage>> taskFactory) => new TimedTask(taskFactory);
}