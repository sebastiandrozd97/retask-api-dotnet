using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Users.Queries
{
  public class CurrentUser
  {
    public class Query : IRequest<UserDto> { }

    public class Handler : IRequestHandler<Query, UserDto>
    {
      private readonly IUserAccessor _userAccessor;
      private readonly UserManager<AppUser> _userManager;
      private readonly IMapper _mapper;
      public Handler(UserManager<AppUser> userManager, IUserAccessor userAccessor, IMapper mapper)
      {
        _mapper = mapper;
        _userManager = userManager;
        _userAccessor = userAccessor;
      }

      public async Task<UserDto> Handle(Query request, CancellationToken cancellationToken)
      {
        var user = await _userManager.FindByNameAsync(_userAccessor.GetCurrentUsername());

        if (user == null)
        {
          throw new RestException(HttpStatusCode.Unauthorized, new { user = "Unauthorized" });
        }

        return _mapper.Map<AppUser, UserDto>(user);
      }
    }
  }
}