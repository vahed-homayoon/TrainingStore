﻿using Shared.DataGrids;
using Shared.MediatR.Messaging;

namespace TrainingStore.Application.Courses.GetCourseList;

public sealed class GetCourseListQuery:
	DataGridRequest, 
    IQuery<DataGridResponse<CourseListResponse>>
{
    public string? Name { get; set; }
}