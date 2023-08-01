namespace HttpLatencyInspector.Dependencies;

internal class ResultFormatter : Abstractions.IFormatter
{
	public string Format(
		string alias,
		int count,
		double average,
		int fastestMs,
		int slowestMs,
		bool areResults
	)
		=> string.Format(
			Consts.MdRow, 
			alias, 
			count, 
			average.ToString("F2"), 
			fastestMs.ToString("F2"), 
			slowestMs.ToString("F2"), 
			areResults
	);
}