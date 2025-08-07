using CodeReview.Users.Api.Shared;
using Shared;

namespace CodeReview.Users.Api.RegisterUser;

public sealed class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, Guid>
{
    public Task<Result<Guid>> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);
        var userId = Guid.CreateVersion7(); 

        return Task.FromResult(Result.Success(userId));
    }

}

