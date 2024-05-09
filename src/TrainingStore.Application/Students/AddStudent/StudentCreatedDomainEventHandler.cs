using MediatR;
using Shared.Email;
using TrainingStore.Domain.Students;
using TrainingStore.Domain.Students.Events;

namespace TrainingStore.Application.Students.AddStudent;

internal sealed class StudentCreatedDomainEventHandler : INotificationHandler<StudentCreatedDomainEvent>
{
	private readonly IStudentRepository _studentRepository;
	private readonly IEmailService _emailService;

	public StudentCreatedDomainEventHandler(
		IStudentRepository studentRepository,
		IEmailService emailService)
	{
		_studentRepository = studentRepository;
		_emailService = emailService;
	}

	public async Task Handle(StudentCreatedDomainEvent notification, CancellationToken cancellationToken)
	{
		Student? student = await _studentRepository.GetByNationalCodeAsync(notification.NationalCode, cancellationToken);
		if (student?.Email is null)
		{
			return;
		}

		string fullName = $"{student.FirstName} {student.SureName}";
		await _emailService.SendWelcomeEmailAsync(fullName, student.Email, cancellationToken);
	}
}
