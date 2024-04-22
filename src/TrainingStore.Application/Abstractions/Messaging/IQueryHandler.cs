using TrainingStore.Domain.Abstractions;
using MediatR;

namespace TrainingStore.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
	where TQuery : IQuery<TResponse>
{
}
