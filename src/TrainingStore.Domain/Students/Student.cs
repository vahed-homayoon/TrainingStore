using TrainingStore.Domain.People;
using TrainingStore.Domain.Students.Events;

namespace TrainingStore.Domain.Students;

public sealed class Student : Person
{
	private Student(
		string nationalCode,
		string firstName,
		string sureName,
		DateTime birthDate,
		string phone,
		string email) :
			base(nationalCode, firstName, sureName, phone, email)
	{
		BirthDate = birthDate;
	}

	public DateTime BirthDate { get; set; }

	public static Student Create(string nationalCode, string firstName, string sureName, DateTime birthDate, string phone, string email)
	{
		var student = new Student(nationalCode, firstName, sureName, birthDate, phone, email);

		student.RaiseDomainEvent(new StudentCreatedDomainEvent(nationalCode));

		return student;
	}

	public void Edit(string nationalCode, string firstName, string sureName, DateTime birthDate, string phone, string email)
	{
		BirthDate = birthDate;

		base.Edit(nationalCode, firstName, sureName, phone, email);
	}
}