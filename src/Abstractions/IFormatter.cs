namespace HttpLatencyInspector.Abstractions;

public interface IFormatter
{
	string Format(
		string alias,
		int count,
		double average,
		int fastestMs,
		int slowestMs,
		bool areResults
	);
}

