using Shared.Entities;

namespace TrainingStore.Domain.Courses;

public sealed class Course : BaseEntity
{
	private Course(
		string name,
		string description)
	{
		Name = name;
		Description = description;
	}

	public string Name { get; private set; }
	public string Description { get; private set; }

	public static Course Create(string name, string description)
	{
		var course = new Course(name, description);

		return course;
	}

	public void Edit(string name, string description)
	{
		Name = name;
		Description = description;
	}
}