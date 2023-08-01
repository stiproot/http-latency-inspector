namespace HttpLatencyInspector.Models;

public class Item
{
	public string Id { get; init; }
	public string Type { get; init; }
	public string Text { get; init; }
	public string Highlight { get; init; }
	public string Description { get; init; }
}

public class Suggestion
{
	public IEnumerable<Item> Items { get; init; }
}