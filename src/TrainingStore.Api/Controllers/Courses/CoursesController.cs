using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrainingStore.Application.Courses.AddCourse;
using TrainingStore.Application.Courses.EditCourse;
using TrainingStore.Application.Courses.GetCourseById;
using TrainingStore.Domain.Abstractions;

namespace TrainingStore.Api.Controllers.Courses
{
	[ApiController]
	[Route("api/Courses")]
	public class CoursesController : ControllerBase
	{
		private readonly ISender _sender;

		public CoursesController(ISender sender)
		{
			_sender = sender;
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetCourseById(int id, CancellationToken cancellationToken)
		{
			var query = new GetCourseByIdQuery(id);

			Result<CourseResponse> response = await _sender.Send(query, cancellationToken);

			return response.IsSuccess ? Ok(response.Value) : NotFound(response.Error);
		}

		[HttpPost]
		public async Task<IActionResult> AddCourse(AddCourseCommand command, CancellationToken cancellationToken)
		{
			Result result = await _sender.Send(command, cancellationToken);

			if (result.IsFailure)
			{
				return BadRequest(result.Error);
			}

			return Ok();
		}

		[HttpPut]
		public async Task<IActionResult> EditCourse(EditCourseCommand command, CancellationToken cancellationToken)
		{
			Result result = await _sender.Send(command, cancellationToken);

			if (result.IsFailure)
			{
				return BadRequest(result.Error);
			}

			return Ok();
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeleteCourse(int id, CancellationToken cancellationToken)
		{
			var command = new DeleteCourseCommand(id);

			Result result = await _sender.Send(command, cancellationToken);

			if (result.IsFailure)
			{
				return BadRequest(result.Error);
			}

			return Ok();
		}
	}
}