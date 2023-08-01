namespace HttpLatencyInspector;

internal class ConfigProcessor : IProcessor<Config>
{
	private readonly IFormatter _formatter;
	private readonly IUrlFactory _urlFactory;
	private readonly IRequestFactory _requestFactory;
	private readonly ITaskFactory _taskFactory;
	private readonly HttpClient _httpClient;
	const int BATCH_SIZE = 40;
	private string? formattedResult;
	public string? FormattedResult => this.formattedResult;

	public ConfigProcessor(
				IFormatter formatter,
				IUrlFactory urlFactory,
				IRequestFactory requestFactory,
				ITaskFactory taskFactory,
				HttpClient httpClient
	 )
	{
		this._formatter = formatter ?? throw new ArgumentNullException(nameof(formatter));
		this._urlFactory = urlFactory ?? throw new ArgumentNullException(nameof(urlFactory));
		this._requestFactory = requestFactory ?? throw new ArgumentNullException(nameof(requestFactory));
		this._taskFactory = taskFactory ?? throw new ArgumentNullException(nameof(taskFactory));
		this._httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
	}

	public async Task<string> ProcessAsync(Config config)
	{
		Uri uri = this._urlFactory.Create(config);
		var inspector = new LoqateResponseInspector();

		IEnumerable<IEnumerable<int>> batches = Enumerable
				.Range(0, config.Count)
				.Batch(BATCH_SIZE);

		var results = new List<TimedTask>();
		foreach (var b in batches)
		{
			var timedTasks = b.Select(i => TimedTaskFactory.Create(() => this._taskFactory.Create(this._httpClient, uri, this._requestFactory.Create(config, uri))).InitAsync());
			results.AddRange(await Task.WhenAll(timedTasks));
		}

		IEnumerable<int> ticks = results.Select(t => t.Timer.DiffAsMilliseconds());
		bool areResults = results.All(r => inspector.Inspect(r.HttpResponseMessageContent));

		double average = ticks.Average();
		int fastest = ticks.Min();
		int slowest = ticks.Max();

		return this._formatter.Format(
			config.Alias,
				config.Count,
				average,
				fastest,
				slowest,
				areResults
		);
	}
}