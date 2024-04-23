﻿using TrainingStore.Application.Abstractions.Messaging;
using TrainingStore.Domain.Abstractions;
using TrainingStore.Domain.Bookings;
using TrainingStore.Domain.Courses;

namespace TrainingStore.Application.Courses.AddCourse;

internal sealed class AddCourseCommandHandler : ICommandHandler<AddCourseCommand>
{
	private readonly ICourseRepository _courseRepository;
	private readonly IUnitOfWork _unitOfWork;

	public AddCourseCommandHandler(
		ICourseRepository courseRepository,
		IUnitOfWork unitOfWork)
	{
		_courseRepository = courseRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(
		AddCourseCommand request,
		CancellationToken cancellationToken)
	{
		var result = await _courseRepository.GetByNameAsync(request.Name, cancellationToken);

		if (result is not null)
		{
			return Result.Failure(CourseErrors.Found);
		}

		var course = Course.Create(
			request.Name,
			request.Description);

		_courseRepository.Add(course);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}
