namespace Shared.Entities;

public abstract class BaseEntity
{
	protected BaseEntity(int id)
	{
		Id = id;
	}

	protected BaseEntity()
	{
	}

	public int Id { get; init; }
}
