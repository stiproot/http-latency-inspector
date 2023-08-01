namespace HttpLatencyInspector.Dependencies;

internal class Consts
{
	public static IDictionary<string, HttpMethod> HttpMethods = new Dictionary<string, HttpMethod>
	{
		{ "GET", HttpMethod.Get },
		{ "POST", HttpMethod.Post },
	};

	public const string MdHeader =
		// "| Alias | Hits | Avg (ms) | Fastest (ms) | Slowest (ms) | Yielded | Url |\n" +
		"| Alias | Hits | Avg (ms) | Fastest (ms) | Slowest (ms) | Yielded |\n" +
		"| --- | --- | --- | --- | --- | --- |\n";

	public const string MdRow =
		"| {0} | {1} | {2} | {3} | {4} | {5} |\n";
}