using System.ComponentModel.DataAnnotations;

namespace Shared.DataGrids;

public class DataGridRequest
{
	[Required]
	public int Page { get; set; }

	[Required]
	public int PageSize { get; set; }
}