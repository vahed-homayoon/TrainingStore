namespace Shared.DataGrids;

public class DataGridResponse<T>
{
	private DataGridResponse(IEnumerable<T> items, int totalCount)
	{
		Items = items;
		TotalCount = totalCount;
	}

	public IEnumerable<T>? Items { get; }

	public int TotalCount { get; }

	public static DataGridResponse<T> Create(IEnumerable<T> items, int totalCount)
	{
		return new DataGridResponse<T>(items, totalCount);
	}
}