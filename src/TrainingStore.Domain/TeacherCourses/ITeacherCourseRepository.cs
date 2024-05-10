namespace TrainingStore.Domain.TeacherCourses;

public interface ITeacherCourseRepository
{

	Task<dynamic> GetListAsync(CancellationToken cancellationToken = default);


	Task<TeacherCourse?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

	Task<TeacherCourse?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);

	void Add(TeacherCourse teacherCourse);

	void Delete(TeacherCourse teacherCourse);
}