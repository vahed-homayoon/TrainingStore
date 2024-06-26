﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.DataGrids;
using Shared.Results;
using TrainingStore.Api.Controllers.Base;
using TrainingStore.Application.TeacherCourses.AddTeacherCourse;
using TrainingStore.Application.TeacherCourses.GetTeacherCourseList;

namespace TrainingStore.Api.Controllers.TeacherCourses
{
	[Route("api/TeacherCourses")]
	public class TeacherCoursesController : BaseController
	{
		private readonly ISender _sender;

		public TeacherCoursesController(ISender sender)
		{
			_sender = sender;
		}

		[HttpGet("List")]
		public async Task<IActionResult> GetList([FromQuery] GetTeacherCourseListQuery query, CancellationToken cancellationToken)
		{
			Result<DataGridResponse<TeacherCourseListResponse>> result = await _sender.Send(query, cancellationToken);

			return ResponseResult(result);
		}

		//[HttpGet("{id:int}")]
		//public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
		//{
		//	var query = new GetCourseByIdQuery(id);

		//	Result<CourseResponse> response = await _sender.Send(query, cancellationToken);

		//	return ResponseResult(response);
		//}

		[HttpPost]
		public async Task<IActionResult> Add([FromBody] AddTeacherCourseCommand command, CancellationToken cancellationToken)
		{
			Result result = await _sender.Send(command, cancellationToken);

			return ResponseResult(result);
		}

		//[HttpPut]
		//public async Task<IActionResult> Edit([FromBody] EditCourseCommand command, CancellationToken cancellationToken)
		//{
		//	Result result = await _sender.Send(command, cancellationToken);

		//	return ResponseResult(result);
		//}

		//[HttpDelete("{id:int}")]
		//public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
		//{
		//	var command = new DeleteCourseCommand(id);

		//	Result result = await _sender.Send(command, cancellationToken);

		//	return ResponseResult(result);
		//}

		//[HttpPatch("RevertStatus")]
		//public async Task<IActionResult> RevertStatus(Guid id, CancellationToken cancellationToken)
		//{
		//	var command = new RevertCourseStatusCommand(id);

		//	Result result = await _sender.Send(command, cancellationToken);

		//	return ResponseResult(result);
		//}
	}
}