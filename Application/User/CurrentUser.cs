using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.User
{
  public class CurrentUser
  {
    public class Query : IRequest<User> { }

    public class Handler : IRequestHandler<Query, User>
    {
      private readonly IUserAccessor _userAccessor;
      private readonly IJwtGenerator _jwtGenerator;
      private readonly UserManager<AppUser> _userManager;
      public Handler(UserManager<AppUser> userManager, IJwtGenerator jwtGenerator, IUserAccessor userAccessor)
      {
        _userManager = userManager;
        _jwtGenerator = jwtGenerator;
        _userAccessor = userAccessor;
      }

      public async Task<User> Handle(Query request, CancellationToken cancellationToken)
      {
        var user = await _userManager.FindByNameAsync(_userAccessor.GetCurrentUsername());

        return new User
        {
          Username = user.UserName,
          FirstName = user.FirstName,
          LastName = user.LastName,
          PhoneNumber = user.PhoneNumber,
          isSupervisor = user.isSupervisor,
          Token = _jwtGenerator.CreateToken(user)
        };
      }
    }
  }
}