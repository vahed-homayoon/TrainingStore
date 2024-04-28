namespace Shared.DataGrids;

public class PagedList<T>
{
	private PagedList(List<T> items, int totalCount)
	{
		Items = items;
		TotalCount = totalCount;
	}

	public List<T>? Items { get; }

	public int TotalCount { get; }

	public static PagedList<T> Create(List<T> items, int totalCount)
	{
		var course = new PagedList<T>(items, totalCount);

		return course;
	}
}