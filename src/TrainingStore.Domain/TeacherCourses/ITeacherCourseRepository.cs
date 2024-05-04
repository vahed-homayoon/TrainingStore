namespace TrainingStore.Domain.TeacherCourses;

public interface ITeacherCourseRepository
{
	Task<TeacherCourse?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

	Task<TeacherCourse?> FindByIdAsync(int id, CancellationToken cancellationToken = default);

	Task<bool> IsDuplicateName(int id, string name, CancellationToken cancellationToken = default);

	void Add(TeacherCourse teacherCourse);

	void Delete(TeacherCourse teacherCourse);
}