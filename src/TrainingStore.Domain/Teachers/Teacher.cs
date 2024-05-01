using TrainingStore.Domain.People;

namespace TrainingStore.Domain.Teachers;

public class Teacher : Person
{
	private Teacher(
		string nationalCode,
		string firstName,
		string sureName,
		string email,
		string phone,
		string address)
			: base(nationalCode, firstName, sureName, email, phone)
	{
		Address = address;
	}

	public string Address { get; private set; }

	public static Teacher Create(string nationalCode, string firstName, string sureName, string email, string phone, string address)
	{
		var teacher = new Teacher(nationalCode, firstName, sureName, email, phone, address);

		return teacher;
	}

	public void Edit(string nationalCode, string firstName, string sureName, string email, string phone, string address)
	{
		base.Edit(nationalCode, firstName, sureName, email, phone);
		Address = address;
	}
}