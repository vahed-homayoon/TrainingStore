using MediatR;
using Shared.Results;

namespace Shared.MediatR.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
