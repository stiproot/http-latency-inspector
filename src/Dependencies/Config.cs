namespace HttpLatencyInspector.Dependencies;

public class Config
{
	public string Alias { get; init; } = string.Empty;
	public string BaseUrl { get; init; } = string.Empty;
	public string BaseRoute { get; init; } = string.Empty;
	public IEnumerable<KeyValuePair> RouteParams { get; init; } = new List<KeyValuePair>();
	public IEnumerable<KeyValuePair> QueryParams { get; init; } = new List<KeyValuePair>();
	public int Count { get; init; } = -1;
	public string Verb { get; init; } = string.Empty;
	public string RequestPayload { get; init; } = string.Empty;
}