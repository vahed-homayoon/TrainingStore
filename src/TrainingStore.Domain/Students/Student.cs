using TrainingStore.Domain.People;

namespace TrainingStore.Domain.Students;

public sealed class Student : Person
{
	private Student(
		string nationalCode,
		string firstName,
		string sureName,
		string phone,
		string email) :
			base(nationalCode, firstName, sureName, phone, email)
	{
	}

	public static Student Create(string nationalCode, string firstName, string sureName, string phone, string email)
	{
		var student = new Student(nationalCode, firstName, sureName, phone, email);

		return student;
	}

	//public void Edit(string nationalCode, string firstName, string sureName, string phone, string email)
	//{
	//	base.Edit(nationalCode, firstName, sureName, phone, email);
	//}
}