using System;
using System.ComponentModel.DataAnnotations;
using Carter;
using CodeReview.UsersBFF.Services;
using CodeReview.UsersBFF.Services.RegisterUser;
using FluentValidation;
using Shared;

namespace CodeReview.UsersBFF.Api.RegisterUser;

public class RegisterUserModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost(UserRoutes.Register, async (RegisterUserRequest request,
                                                IValidator<RegisterUserRequest>validator,
                                                IRegisterUserService registerUserService,
                                                CancellationToken cancellationToken) =>
        {
            FluentValidation.Results.ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return Results.ValidationProblem(validationResult.ToDictionary());
            }
            Result<Guid> result = await registerUserService.RegisterAsync(request, cancellationToken);
            if (result.IsSuccess)
            {
                // Replace "/users/{id}" with the actual route if you have a GET endpoint for the user
                return Results.Created($"/users/{result.Value}", result);
            }
            return Results.BadRequest(result);
        });
    }
}
