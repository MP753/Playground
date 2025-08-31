using CodeReview.Users.Api.RegisterUser;
using Shared;

namespace CodeReview.Users.Api.Shared;

public interface ICommandHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
    Task<Result<TResponse>> Handle(TCommand command, CancellationToken cancellationToken);
}
