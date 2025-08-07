using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeReview.UsersBFF.Services.RegisterUser;
using Refit;
using Shared;

namespace CodeReview.UsersBFF.Services.HttpClients;
public interface IUserApi
{
    [Post(UserRoutes.Register)]
    Task<Result<Guid>> RegisterAsync([Body] RegisterUserRequest request);
}
