namespace HttpLatencyInspector.Dependencies;

public interface IResponseInspector
{
	bool Inspect(string content);
}

public class LoqateResponseInspector : IResponseInspector
{
	public bool Inspect(string content)
	{
		if (string.IsNullOrWhiteSpace(content)) return false;

		var document = JsonDocument.Parse(content);

		var root = document.RootElement;

		var items = root.GetProperty("Items");

		return items.GetArrayLength() > 0;
	}
}

public interface ITimedTask
{
	Task<TimedTask> InitAsync();
	HttpResponseMessage HttpResponseMessage { get; }
	string? HttpResponseMessageContent { get; }
}

public abstract class BaseTimedTask
{
	protected HttpResponseMessage _HttpResponseMessage { get; set; }
	protected string? _HttpResponseMessageContent { get; set; }

	public virtual HttpResponseMessage HttpResponseMessage => this._HttpResponseMessage;
	public virtual string? HttpResponseMessageContent => this._HttpResponseMessageContent;
}

public class TimedTask : BaseTimedTask, ITimedTask
{
	private readonly Func<Task<HttpResponseMessage>> _taskFactory;
	public readonly Timer Timer = new Timer();
	private Task<HttpResponseMessage>? task;

	public TimedTask(Func<Task<HttpResponseMessage>> taskFactory) => this._taskFactory = taskFactory;

	public async Task<TimedTask> InitAsync()
	{
		this.Timer.Start();
		this.task = this._taskFactory();
		this._HttpResponseMessage = await this.task;
		this.Timer.Stop();
		this._HttpResponseMessage.EnsureSuccessStatusCode();
		this._HttpResponseMessageContent = await this._HttpResponseMessage.Content.ReadAsStringAsync();
		return this;
	}
}