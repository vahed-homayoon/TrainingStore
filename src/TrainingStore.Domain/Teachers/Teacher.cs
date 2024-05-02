using TrainingStore.Domain.People;

namespace TrainingStore.Domain.Teachers;

public sealed class Teacher : Person
{
	private Teacher(
		string nationalCode,
		string firstName,
		string sureName,
		string phone,
		string email,
		string address):
			base(nationalCode, firstName, sureName, phone, email)
	{
		Address = address;
	}

	public string Address { get; private set; }

	public static Teacher Create(string nationalCode, string firstName, string sureName, string phone, string email, string address)
	{
		var teacher = new Teacher(nationalCode, firstName, sureName, phone, email, address);

		return teacher;
	}

	public void Edit(string nationalCode, string firstName, string sureName, string phone, string email, string address)
	{
		base.Edit(nationalCode, firstName, sureName, phone, email);
		Address = address;
	}
}