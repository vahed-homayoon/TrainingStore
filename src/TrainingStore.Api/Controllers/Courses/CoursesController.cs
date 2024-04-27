using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Results;
using TrainingStore.Api.Controllers.Base;
using TrainingStore.Application.Courses.AddCourse;
using TrainingStore.Application.Courses.DeleteCourse;
using TrainingStore.Application.Courses.EditCourse;
using TrainingStore.Application.Courses.GetCourseById;
using TrainingStore.Application.Courses.GetCourseList;

namespace TrainingStore.Api.Controllers.Courses
{
	//[ApiController]
	[Route("api/Courses")]
	public class CoursesController : BaseController
	{
		private readonly ISender _sender;

		public CoursesController(ISender sender)
		{
			_sender = sender;
		}

		[HttpGet("List")]
		public async Task<IActionResult> CourseList(CancellationToken cancellationToken)
		{
			var query = new GetCourseListQuery();

			Result<IReadOnlyList<CourseListResponse>> result = await _sender.Send(query, cancellationToken);

			return ResponseResult(result);
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetCourseById(int id, CancellationToken cancellationToken)
		{
			var query = new GetCourseByIdQuery(id);

			Result<CourseResponse> response = await _sender.Send(query, cancellationToken);

			return ResponseResult(response);
		}

		[HttpPost]
		public async Task<IActionResult> AddCourse([FromBody] AddCourseCommand command, CancellationToken cancellationToken)
		{
			Result result = await _sender.Send(command, cancellationToken);
			
			return ResponseResult(result);
		}

		[HttpPut]
		public async Task<IActionResult> EditCourse([FromBody] EditCourseCommand command, CancellationToken cancellationToken)
		{
			Result result = await _sender.Send(command, cancellationToken);

			return ResponseResult(result);
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeleteCourse(int id, CancellationToken cancellationToken)
		{
			var command = new DeleteCourseCommand(id);

			Result result = await _sender.Send(command, cancellationToken);

			return ResponseResult(result);
		}
	}
}