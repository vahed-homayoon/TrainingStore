using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.DataGrids;
using Shared.Results;
using TrainingStore.Api.Controllers.Base;
using TrainingStore.Application.Students.AddStudent;
using TrainingStore.Application.Students.DeleteStudent;
using TrainingStore.Application.Students.EditStudent;
using TrainingStore.Application.Students.GetStudentList;
using TrainingStore.Application.Students.RevertStudentStatus;

namespace TrainingStore.Api.Controllers.Students
{
	[Route("api/Students")]
	public class StudentsController : BaseController
	{
		private readonly ISender _sender;

		public StudentsController(ISender sender)
		{
			_sender = sender;
		}

		[HttpGet("List")]
		public async Task<IActionResult> GetList([FromQuery] GetStudentListQuery query, CancellationToken cancellationToken)
		{
			Result<DataGridResponse<StudentListResponse>> result = await _sender.Send(query, cancellationToken);

			return ResponseResult(result);
		}

		[HttpPost]
		public async Task<IActionResult> Add([FromBody] AddStudentCommand command, CancellationToken cancellationToken)
		{
			Result result = await _sender.Send(command, cancellationToken);

			return ResponseResult(result);
		}

		[HttpPut]
		public async Task<IActionResult> Edit([FromBody] EditStudentCommand command, CancellationToken cancellationToken)
		{
			Result result = await _sender.Send(command, cancellationToken);

			return ResponseResult(result);
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
		{
			var command = new DeleteStudentCommand(id);

			Result result = await _sender.Send(command, cancellationToken);

			return ResponseResult(result);
		}

		[HttpPatch("RevertStatus")]
		public async Task<IActionResult> RevertStatus(Guid id, CancellationToken cancellationToken)
		{
			var command = new RevertStudentStatusCommand(id);

			Result result = await _sender.Send(command, cancellationToken);

			return ResponseResult(result);
		}
	}
}