using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.DataGrids;
using Shared.Results;
using TrainingStore.Api.Controllers.Base;
using TrainingStore.Application.Teachers.AddTeacher;
using TrainingStore.Application.Teachers.DeleteTeacher;
using TrainingStore.Application.Teachers.EditTeacher;
using TrainingStore.Application.Teachers.GetTeacherList;

namespace TrainingStore.Api.Controllers.Teachers
{
	[Route("api/Teachers")]
	public class TeachersController : BaseController
	{
		private readonly ISender _sender;

		public TeachersController(ISender sender)
		{
			_sender = sender;
		}

		[HttpGet("List")]
		public async Task<IActionResult> GetList([FromQuery] GetTeacherListQuery query, CancellationToken cancellationToken)
		{
			Result<DataGridResponse<TeacherListResponse>> result = await _sender.Send(query, cancellationToken);

			return ResponseResult(result);
		}

		[HttpPost]
		public async Task<IActionResult> Add([FromBody] AddTeacherCommand command, CancellationToken cancellationToken)
		{
			Result result = await _sender.Send(command, cancellationToken);

			return ResponseResult(result);
		}

		[HttpPut]
		public async Task<IActionResult> Edit([FromBody] EditTeacherCommand command, CancellationToken cancellationToken)
		{
			Result result = await _sender.Send(command, cancellationToken);

			return ResponseResult(result);
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
		{
			var command = new DeleteTeacherCommand(id);

			Result result = await _sender.Send(command, cancellationToken);

			return ResponseResult(result);
		}
	}
}