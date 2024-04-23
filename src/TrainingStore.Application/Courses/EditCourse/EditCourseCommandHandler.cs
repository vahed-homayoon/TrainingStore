﻿using TrainingStore.Application.Abstractions.Messaging;
using TrainingStore.Domain.Abstractions;
using TrainingStore.Domain.Bookings;
using TrainingStore.Domain.Courses;

namespace TrainingStore.Application.Courses.EditCourse;

internal sealed class EditCourseCommandHandler : ICommandHandler<EditCourseCommand>
{
	private readonly ICourseRepository _courseRepository;
	private readonly IUnitOfWork _unitOfWork;

	public EditCourseCommandHandler(
		ICourseRepository courseRepository,
		IUnitOfWork unitOfWork)
	{
		_courseRepository = courseRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(
		EditCourseCommand request,
		CancellationToken cancellationToken)
	{
		var course = await _courseRepository.GetByIdAsync(request.Id, cancellationToken);

		if (course is null)
		{
			return Result.Failure(CourseErrors.NotFound);
		}

		course.Edit(
			course.Id,
			request.Name,
			request.Description);

		_courseRepository.Edit(course);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}
