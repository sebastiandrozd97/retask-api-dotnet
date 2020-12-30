using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Users.Queries
{
  public class List
  {
    public class Query : IRequest<List<UserDto>> { }

    public class Handler : IRequestHandler<Query, List<UserDto>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      private readonly IUserAccessor _userAccessor;
      private readonly UserManager<AppUser> _userManager;
      public Handler(DataContext context, IMapper mapper, IUserAccessor userAccessor, UserManager<AppUser> userManager)
      {
        _userManager = userManager;
        _userAccessor = userAccessor;
        _mapper = mapper;
        _context = context;
      }

      public async Task<List<UserDto>> Handle(Query request, CancellationToken cancellationToken)
      {
        var user = await _userManager.FindByNameAsync(_userAccessor.GetCurrentUsername());

        if (user == null || !user.IsSupervisor)
        {
          throw new RestException(HttpStatusCode.Unauthorized, new { user = "Unauthorized" });
        }

        var workers = await _context.Users.ToListAsync();

        return _mapper.Map<List<AppUser>, List<UserDto>>(workers);
      }
    }
  }
}