using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrainingStore.Application.Courses.AddCourse;
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

		[HttpPost]
		public async Task<IActionResult> AddCourse(AddCourseRequest request, CancellationToken cancellationToken)
		{
			var command = new AddCourseCommand(request.CourseId, request.Name, request.Description);

			Result result = await _sender.Send(command, cancellationToken);

			if (result.IsFailure)
			{
				return BadRequest(result.Error);
			}

			return Ok();
		}
	}
}