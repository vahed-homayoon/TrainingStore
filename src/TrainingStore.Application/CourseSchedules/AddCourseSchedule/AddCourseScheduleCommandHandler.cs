using Shared.DbContexts;
using Shared.MediatR.Messaging;
using Shared.Results;
using TrainingStore.Domain.CourseSchedules;

namespace TrainingStore.Application.CourseSchedules.AddCourseSchedule;

internal sealed class AddCourseScheduleCommandHandler : ICommandHandler<AddCourseScheduleCommand>
{
	private readonly ICourseScheduleRepository _courseScheduleRepository;
	private readonly IUnitOfWork _unitOfWork;

	public AddCourseScheduleCommandHandler(
		ICourseScheduleRepository courseScheduleRepository,
		IUnitOfWork unitOfWork)
	{
		_courseScheduleRepository = courseScheduleRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(
		AddCourseScheduleCommand request,
		CancellationToken cancellationToken)
	{
		//var isDuplicateName = await _courseScheduleRepository.IsDuplicateName(0, request.Name, cancellationToken);

		//if (isDuplicateName)
		//{
		//	return Result.Failure(CourseScheduleErrors.DuplicateName);
		//}

		//var course = CourseSchedule.Create(
		//	request.CourseId,
		//	request.TeacherId,
		//	request.StartDate,
		//	request.EndDate,
		//	request.FromHour,
		//	request.ToHour);

		//_courseScheduleRepository.Add(course);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}
