using System;
using Carter;
using CodeReview.UsersBFF.Services;
using CodeReview.UsersBFF.Services.RegisterUser;
using Shared;

namespace CodeReview.UsersBFF.Api.RegisterUser;

public class RegisterUserModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost(UserRoutes.Register, async (RegisterUserRequest request,
                                                IRegisterUserService registerUserService,
                                                CancellationToken cancellationToken) =>
        {
            Guid result = await registerUserService.RegisterAsync(request, cancellationToken);
            return Results.Ok(result);
        });
    }
}
