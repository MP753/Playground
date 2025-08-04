using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace CodeReview.UsersBFF.Services.RegisterUser;
public class RegisterUserService(HttpClient httpClient) : IRegisterUserService
{
    public async Task<Guid> RegisterAsync(RegisterUserRequest request,
                                CancellationToken cancellationToken)
    {
        HttpResponseMessage response = await httpClient.PostAsJsonAsync(UserRoutes.Register, request, cancellationToken);
        response.EnsureSuccessStatusCode();

        Guid userId = await response.Content.ReadFromJsonAsync<Guid>(cancellationToken: cancellationToken);
        return userId!;
    }
}
