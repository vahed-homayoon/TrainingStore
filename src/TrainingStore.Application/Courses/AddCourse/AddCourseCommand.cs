﻿using TrainingStore.Application.Abstractions.Messaging;
using TrainingStore.Domain.Abstractions;

namespace TrainingStore.Application.Courses.AddCourse;

public sealed record AddCourseCommand(
	string Name,
	string Description) : ICommand;
