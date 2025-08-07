namespace CodeReview.Users.Api.Shared;

public interface ICommand<TResponse> {
    Type ResponseType => typeof(TResponse);

}


