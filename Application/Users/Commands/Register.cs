using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Validators;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Users.Commands
{
  public class Register
  {
    public class Command : IRequest<User>
    {
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string UserName { get; set; }
      public string PhoneNumber { get; set; }
      public string Email { get; set; }
      public string Password { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.UserName).NotEmpty();
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).Password();
      }
    }
    public class Handler : IRequestHandler<Command, User>
    {

      private readonly DataContext _context;
      private readonly UserManager<AppUser> _userManager;
      private readonly IMapper _mapper;

      public Handler(DataContext context, UserManager<AppUser> userManager, IMapper mapper)
      {
        _mapper = mapper;
        _userManager = userManager;
        _context = context;
      }

      public async Task<User> Handle(Command request, CancellationToken cancellationToken)
      {
        if (await _context.Users.AnyAsync(x => x.Email == request.Email))
        {
          throw new RestException(HttpStatusCode.BadRequest, new { Email = "Email already exists" });
        }

        if (await _context.Users.AnyAsync(x => x.UserName == request.UserName))
        {
          throw new RestException(HttpStatusCode.BadRequest, new { Username = "Username already exists" });
        }

        var user = new AppUser
        {
          FirstName = request.FirstName,
          LastName = request.LastName,
          PhoneNumber = request.PhoneNumber,
          IsSupervisor = true,
          IsHired = true,
          Email = request.Email,
          UserName = request.UserName,
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (result.Succeeded)
        {
          return _mapper.Map<AppUser, User>(user);
        }

        throw new Exception("Problem creating user");
      }
    }
  }
}