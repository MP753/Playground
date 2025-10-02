namespace Shared;

public record Error(string Code, string Name)
{
    public static readonly Error None = new(string.Empty, string.Empty);

    public static readonly Error NullValue = new("Error.NullValue", "Null value was provided");
    public object? Metadata { get; init; }
    public static Error Validation(IDictionary<string, string[]> failures) =>
        new("Error.Validation", "One or more validation errors occurred")
        {
            Metadata = failures
        };


}
