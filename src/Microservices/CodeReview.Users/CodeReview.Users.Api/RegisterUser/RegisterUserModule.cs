using Carter;
using CodeReview.Users.Api.Shared;
using Shared;

namespace CodeReview.Users.Api.RegisterUser;

public class RegisterUserModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost(UserRoutes.Register, async (RegisterUserCommand command,
                                                ICommandHandler<RegisterUserCommand, Guid> handler,
                                                CancellationToken cancellationToken) =>
        {
            Result result = await handler.Handle(command, cancellationToken);
            return result;
        });
    }
}
