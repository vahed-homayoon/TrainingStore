using System.Text.Json.Serialization;

namespace TrainingStore.Domain.Abstractions;

public class Result
{
	#region Properties

	public bool IsSuccess { get; protected set; }

	[JsonIgnore]
	public List<Error> Errors { get; private set; } = new List<Error>();

	public bool IsFailure { get { return !IsSuccess; } }

	public List<string> ErrorMessages
	{
		get
		{
			return Errors.Select(m => m.Description).ToList();
		}
	}

	#endregion

	#region Ctors

	protected Result()
	{

	}

	protected Result(Error message)
	{
		Errors = new List<Error>() { message };
		IsSuccess = false;
	}

	protected Result(List<Error> messages)
	{
		Errors = messages;
		IsSuccess = false;
	}

	#endregion

	#region Methods

	public static Result Success()
	{
		return new Result()
		{
			IsSuccess = true,
		};
	}

	public static Result Failure(Error message)
	{
		return new Result(message);
	}

	public static Result Failure(List<Error> messages)
	{
		return new Result(messages);
	}


	public Result<T> ToResult<T>(T value)
	{
		return new Result<T>(value, Errors) { IsSuccess = IsSuccess };
	}

	protected Result ToResult<T>(Result<T> result)
	{
		return new Result(result.Errors) { IsSuccess = result.IsSuccess };
	}

	public override string ToString()
	{
		return string.Join('.', Errors.Select(m => m.Description).ToList());
	}

	#endregion
}

public class Result<T> : Result
{
	#region Properties

	public T Data { get; private set; }

	#endregion

	#region Ctors

	private Result()
	{

	}

	private Result(T data)
	{
		Data = data;
	}

	private Result(T data, Error message) : base(message)
	{
		Data = data;
	}

	internal Result(T data, List<Error> messages) : base(messages)
	{
		Data = data;
	}

	#endregion

	#region Methods

	public static Result<TResult> Success<TResult>(TResult value)
	{
		return new Result<TResult>(value)
		{
			IsSuccess = true,
		};
	}

	public static Result<TResult> Failure<TResult>(Error message)
	{
		return new Result<TResult>(default, message);
	}


	public static Result<TResult> Failure<TResult>(List<Error> messages)
	{
		return new Result<TResult>(default, messages);
	}

	public static Result<TResult> Failure<TResult>(Error message, TResult value)
	{
		return new Result<TResult>(value, message);
	}

	public static Result<TResult> Failure<TResult>(List<Error> messages, TResult value)
	{
		return new Result<TResult>(value, messages);
	}

	public Result ToResult()
	{
		return ToResult(this);
	}

	public override string ToString()
	{
		return base.ToString();
	}

	#endregion
}