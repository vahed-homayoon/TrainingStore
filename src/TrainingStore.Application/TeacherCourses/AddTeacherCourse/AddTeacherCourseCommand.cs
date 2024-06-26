﻿using Shared.MediatR.Messaging;
using TrainingStore.Domain.TeacherCourses;

namespace TrainingStore.Application.TeacherCourses.AddTeacherCourse;

public sealed record AddTeacherCourseCommand(
	Guid CourseId,
	Guid TeacherId,
	DateTime StartDate,
	DateTime EndDate,
	List<CourseSchedule> CourseSchedules) : ICommand;