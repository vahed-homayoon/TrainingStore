using TrainingStore.Domain.People;
using TrainingStore.Domain.Teachers.Events;

namespace TrainingStore.Domain.Teachers;

public sealed class Teacher : Person
{
	private Teacher()
	{
	}

	private Teacher(
		Guid id,
		string nationalCode,
		string firstName,
		string sureName,
		string phone,
		string email,
		string address) :
			base(id, nationalCode, firstName, sureName, phone, email)
	{
		Address = address;
	}

	public string Address { get; private set; }

	public static Teacher Create(string nationalCode, string firstName, string sureName, string phone, string email, string address)
	{
		var teacher = new Teacher(Guid.NewGuid(), nationalCode, firstName, sureName, phone, email, address);

		if (email is not null)
		{
			teacher.RaiseDomainEvent(new TeacherCreatedDomainEvent(teacher.Id));
		}

		return teacher;
	}

	public void Edit(string nationalCode, string firstName, string sureName, string phone, string email, string address)
	{
		base.Edit(nationalCode, firstName, sureName, phone, email);
		Address = address;
	}
}