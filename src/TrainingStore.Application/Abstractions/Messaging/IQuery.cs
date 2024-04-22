using TrainingStore.Domain.Abstractions;
using MediatR;

namespace TrainingStore.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
