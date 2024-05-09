using Shared.Entities;

namespace TrainingStore.Domain.People;

public abstract class Person : BaseEntity, IAuditable
{
	protected Person(
		string nationalCode,
		string firstName,
		string sureName,
		string phone,
		string? email)
	{
		NationalCode = nationalCode;
		FirstName = firstName;
		SureName = sureName;
		Phone = phone;
		Email = email;
		IsActive = true;
	}

	public string NationalCode { get; private set; }

	public string FirstName { get; private set; }

	public string SureName { get; private set; }

	public string Phone { get; private set; }

	public string? Email { get; private set; }

    public bool IsActive { get; private set; }

	public void Edit(string nationalCode, string firstName, string sureName, string phone, string email)
	{
		NationalCode = nationalCode;
		FirstName = firstName;
		SureName = sureName;
		Phone = phone;
		Email = email;
	}

	public void RevertStatus()
	{
		IsActive = !IsActive;
	}
}