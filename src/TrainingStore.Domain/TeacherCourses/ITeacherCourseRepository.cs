namespace TrainingStore.Domain.TeacherCourses;

public interface ITeacherCourseRepository
{

	Task<dynamic> GetListAsync(CancellationToken cancellationToken = default);


	Task<TeacherCourse?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

	Task<TeacherCourse?> FindByIdAsync(int id, CancellationToken cancellationToken = default);

	void Add(TeacherCourse teacherCourse);

	void Delete(TeacherCourse teacherCourse);
}