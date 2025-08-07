using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace CodeReview.UsersBFF.Services.RegisterUser;

public interface IRegisterUserService
{
    Task<Result<Guid>> RegisterAsync(RegisterUserRequest request, CancellationToken cancellationToken);

}
