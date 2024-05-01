using TrainingStore.Domain.People;

namespace TrainingStore.Domain.Students;

public class Student : Person
{
	private Student(
		string nationalCode,
		string firstName,
		string sureName,
		string email,
		string phone)
			: base(nationalCode, firstName, sureName, email, phone)
	{

	}

	public static Student Create(string nationalCode, string firstName, string sureName, string email, string phone)
	{
		var student = new Student(nationalCode, firstName, sureName, email, phone);

		return student;
	}
}