using System.Data;
using TrainingStore.Domain.Abstractions;

namespace TrainingStore.Domain.Courses;

public sealed class Course : Entity
{
    private Course(
        Guid id,
        string name,
        string description
        )
        :base(id)
	{
		Name = name;
		Description = description;
	}

    public string Name { get; private set; }
    public string Description { get; private set; }

	public static Course Create(string name, string description)
	{
		var course = new Course(Guid.NewGuid(), name, description);

		return course;
	}
}