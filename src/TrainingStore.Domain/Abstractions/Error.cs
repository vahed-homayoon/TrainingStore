namespace TrainingStore.Domain.Abstractions;

public record Error(string Key, string Description)
{
	//public static readonly Error None = new(string.Empty, string.Empty);

	//public static readonly Error NullValue = new("Error.NullValue", "Null value was provided");
}
