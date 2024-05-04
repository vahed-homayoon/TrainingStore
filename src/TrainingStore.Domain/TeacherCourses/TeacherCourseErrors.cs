using Shared.Results;

namespace TrainingStore.Domain.TeacherCourses;

public static class TeacherCourseErrors
{
	public static readonly Error DuplicateName = new(
		"TeacherCourse.DuplicateName",
		"1111111111");

	public static readonly Error NotFound = new(
		"TeacherCourse.NotFound",
		"2222222222");
}