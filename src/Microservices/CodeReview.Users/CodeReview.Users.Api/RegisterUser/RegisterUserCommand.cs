using CodeReview.Users.Api.Shared;

namespace CodeReview.Users.Api.RegisterUser;

public sealed record RegisterUserCommand(string Email, string FirstName, string LastName, string Password) : ICommand<Guid>;

