using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReview.UsersBFF.Services.RegisterUser;

public interface IRegisterUserService
{
    Task<Guid> RegisterAsync(RegisterUserRequest request, CancellationToken cancellationToken);

}
