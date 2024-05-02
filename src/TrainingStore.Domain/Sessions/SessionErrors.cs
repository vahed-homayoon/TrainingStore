using Shared.Results;

namespace TrainingStore.Domain.Sessions;

public static class SessionErrors
{
	public static readonly Error DuplicateName = new(
		"Session.DuplicateName",
		"1111111111");

	public static readonly Error NotFound = new(
		"Session.NotFound",
		"2222222222");
}