using MediatR;
using Shared.Email;
using TrainingStore.Domain.Teachers;
using TrainingStore.Domain.Teachers.Events;

namespace TrainingStore.Application.Teachers.AddTeacher;

internal sealed class TeacherCreatedDomainEventHandler : INotificationHandler<TeacherCreatedDomainEvent>
{
	private readonly ITeacherRepository _teacherRepository;
	private readonly IEmailService _emailService;

	public TeacherCreatedDomainEventHandler(
		ITeacherRepository teacherRepository,
		IEmailService emailService)
	{
		_teacherRepository = teacherRepository;
		_emailService = emailService;
	}

	public async Task Handle(TeacherCreatedDomainEvent notification, CancellationToken cancellationToken)
	{
		var teacher = await _teacherRepository.GetByIdAsync(notification.Id, cancellationToken);
		if (teacher?.Email is null)
		{
			return;
		}

		string fullName = $"{teacher.FirstName} {teacher.SureName}";
		await _emailService.SendWelcomeEmailAsync(fullName, teacher.Email, cancellationToken);
	}
}
