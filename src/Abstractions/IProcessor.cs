namespace HttpLatencyInspector.Abstractions;

public interface IProcessor<TToProcess>
{
	Task<string> ProcessAsync(TToProcess config);
}
