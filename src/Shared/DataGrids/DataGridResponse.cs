namespace Shared.DataGrids;

public class DataGridResponse<T>
{
	private DataGridResponse(List<T> items, int totalCount)
	{
		Items = items;
		TotalCount = totalCount;
	}

	public List<T>? Items { get; }

	public int TotalCount { get; }

	public static DataGridResponse<T> Create(List<T> items, int totalCount)
	{
		return new DataGridResponse<T>(items, totalCount);
	}
}