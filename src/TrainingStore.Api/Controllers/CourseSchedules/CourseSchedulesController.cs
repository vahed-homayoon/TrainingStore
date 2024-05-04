using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.DataGrids;
using Shared.Results;
using TrainingStore.Api.Controllers.Base;
using TrainingStore.Application.CourseSchedules.AddCourseSchedule;


namespace TrainingStore.Api.Controllers.CourseSchedules
{
	[Route("api/CourseSchedules")]
	public class CourseSchedulesController : BaseController
	{
		private readonly ISender _sender;

		public CourseSchedulesController(ISender sender)
		{
			_sender = sender;
		}

		//[HttpGet("List")]
		//public async Task<IActionResult> GetList([FromQuery] GetCourseListQuery query, CancellationToken cancellationToken)
		//{
		//	Result<DataGridResponse<CourseListResponse>> result = await _sender.Send(query, cancellationToken);

		//	return ResponseResult(result);
		//}

		//[HttpGet("{id:int}")]
		//public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
		//{
		//	var query = new GetCourseByIdQuery(id);

		//	Result<CourseResponse> response = await _sender.Send(query, cancellationToken);

		//	return ResponseResult(response);
		//}

		[HttpPost]
		public async Task<IActionResult> Add([FromBody] AddCourseScheduleCommand command, CancellationToken cancellationToken)
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
		//public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
		//{
		//	var command = new DeleteCourseCommand(id);

		//	Result result = await _sender.Send(command, cancellationToken);

		//	return ResponseResult(result);
		//}

		//[HttpPatch("RevertStatus")]
		//public async Task<IActionResult> RevertStatus(int id, CancellationToken cancellationToken)
		//{
		//	var command = new RevertCourseStatusCommand(id);

		//	Result result = await _sender.Send(command, cancellationToken);

		//	return ResponseResult(result);
		//}
	}
}