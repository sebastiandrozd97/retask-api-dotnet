using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Interfaces;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Persistence;

namespace Application.Users.Commands
{
  public class Edit
  {
    public class Command : IRequest<UserDto>
    {
      public string Id { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string PhoneNumber { get; set; }
      public string UserName { get; set; }
      public bool IsSupervisor { get; set; }
      public bool IsHired { get; set; }

    }

    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.PhoneNumber).NotEmpty();
        RuleFor(x => x.UserName).NotEmpty();
        RuleFor(x => x.IsHired).NotEmpty();
        RuleFor(x => x.IsSupervisor).NotEmpty();
      }
    }

    public class Handler : IRequestHandler<Command, UserDto>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      private readonly UserManager<AppUser> _userManager;
      private readonly IUserAccessor _userAccessor;
      public Handler(DataContext context, IMapper mapper, UserManager<AppUser> userManager, IUserAccessor userAccessor)
      {
        _userAccessor = userAccessor;
        _userManager = userManager;
        _mapper = mapper;
        _context = context;
      }

      public async Task<UserDto> Handle(Command request, CancellationToken cancellationToken)
      {
        var currentUser = await _userManager.FindByNameAsync(_userAccessor.GetCurrentUsername());

        if (!currentUser.IsSupervisor)
        {
          throw new RestException(HttpStatusCode.Unauthorized, new { currentUser = "Unauthorized" });
        }

        var user = await _context.Users.FindAsync(request.Id);

        if (user == null)
        {
          throw new RestException(HttpStatusCode.NotFound, new { user = "Not found" });
        }

        user.FirstName = request.FirstName ?? user.FirstName;
        user.LastName = request.LastName ?? user.LastName;
        user.PhoneNumber = request.PhoneNumber ?? user.PhoneNumber;
        user.UserName = request.UserName ?? user.UserName;
        user.IsSupervisor = request.IsSupervisor;
        user.IsHired = request.IsHired;

        var success = await _context.SaveChangesAsync() > 0;

        if (success)
        {
          return _mapper.Map<AppUser, UserDto>(user);
        }

        throw new Exception("Problem saving changes");
      }
    }
  }
}