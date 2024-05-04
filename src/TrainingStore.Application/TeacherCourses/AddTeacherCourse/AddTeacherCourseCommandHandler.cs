using Shared.DbContexts;
using Shared.MediatR.Messaging;
using Shared.Results;
using TrainingStore.Domain.TeacherCourses;

namespace TrainingStore.Application.TeacherCourses.AddTeacherCourse;

internal sealed class AddTeacherCourseCommandHandler : ICommandHandler<AddTeacherCourseCommand>
{
	private readonly ITeacherCourseRepository _teacherCourseRepository;
	private readonly IUnitOfWork _unitOfWork;

	public AddTeacherCourseCommandHandler(
		ITeacherCourseRepository teacherCourseRepository,
		IUnitOfWork unitOfWork)
	{
		_teacherCourseRepository = teacherCourseRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(
		AddTeacherCourseCommand request,
		CancellationToken cancellationToken)
	{

		var course = TeacherCourse.Create(
			request.CourseId,
			request.TeacherId,
			request.StartDate,
			request.EndDate,
			request.FromHour,
			request.ToHour);

		_teacherCourseRepository.Add(course);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}