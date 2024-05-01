using Shared.Entities;

namespace TrainingStore.Domain.People;

public abstract class Person : BaseEntity
{
	public Person(
		string nationalCode,
		string firstName,
		string sureName,
		string email,
		string phone)
	{
		NationalCode = nationalCode;
		FirstName = firstName;
		SureName = sureName;
		Email = email;
		Phone = phone;
	}

	public string NationalCode { get; private set; }

	public string FirstName { get; private set; }

	public string SureName { get; private set; }

	public string Email { get; private set; }

	public string Phone { get; private set; }

	protected void Edit(string nationalCode, string firstName, string sureName, string email, string phone)
	{
		NationalCode = nationalCode;
		FirstName = firstName;
		SureName = sureName;
		Email = email;
		Phone = phone;
	}
}