
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using FluentValidation.Results;
using Shared;

namespace CodeReview.Users.Api.Shared;
internal sealed class ValidationCommandHandler<TCommand, TResponse>(
    ICommandHandler<TCommand, TResponse> innerHandler,
    IEnumerable<IValidator<TCommand>> validators)
    : ICommandHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
    public async Task<Result<TResponse>> Handle(TCommand command, CancellationToken cancellationToken)
    {
        ValidationFailure[] validationFailures = await ValidateAsync(command, validators);

        if (validationFailures.Length == 0)
        {
            return await innerHandler.Handle(command, cancellationToken);
        }

        var errorDict = validationFailures
                        .GroupBy(f => f.PropertyName)
                        .ToDictionary(
                             g => g.Key,
                             g => g.Select(f => f.ErrorMessage).ToArray()
                        );

        return Result.Failure<TResponse>(Error.Validation(errorDict));
    }

    private static async Task<ValidationFailure[]> ValidateAsync<TCommandType>(
        TCommandType command,
        IEnumerable<IValidator<TCommandType>> validators)
    {
        if (!validators.Any())
        {
            return [];
        }

        var context = new ValidationContext<TCommandType>(command);

        FluentValidation.Results.ValidationResult[] validationResults = await Task.WhenAll(
            validators.Select(validator => validator.ValidateAsync(context)));

        ValidationFailure[] validationFailures = validationResults
            .Where(validationResult => !validationResult.IsValid)
            .SelectMany(validationResult => validationResult.Errors)
            .ToArray();

        return validationFailures;
    }




}
