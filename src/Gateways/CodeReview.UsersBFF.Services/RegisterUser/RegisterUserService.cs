using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using CodeReview.UsersBFF.Services.HttpClients;
using Shared;

namespace CodeReview.UsersBFF.Services.RegisterUser;
public class RegisterUserService(IUserApi userApi) : IRegisterUserService
{
    public async Task<Result<Guid>> RegisterAsync(RegisterUserRequest request,
                                CancellationToken cancellationToken)
    {
        Result<Guid> response = await userApi.RegisterAsync(request);
        return response;
    }


}
