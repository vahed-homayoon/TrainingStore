using Shared.Entities;

namespace TrainingStore.Domain.Courses;

public sealed class Course : BaseEntity, IAuditable
{
	private Course()
	{
	}

	private Course(
		Guid id,
		string name,
		string description) :
			base(id)
	{
		Name = name;
		Description = description;
		IsActive = true;
	}

	public string Name { get; private set; }
	public string Description { get; private set; }
	public bool IsActive { get; private set; }

	public static Course Create(string name, string description)
	{
		var course = new Course(Guid.NewGuid(), name, description);

		return course;
	}

	public void Edit(string name, string description)
	{
		Name = name;
		Description = description;
	}

	public void RevertStatus()
	{
		IsActive = !IsActive;
	}
}