using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Interfaces;
using Application.Validators;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.User
{
  public class Register
  {
    public class Command : IRequest<User>
    {
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string PhoneNumber { get; set; }
      public string Username { get; set; }
      public bool isSupervisor { get; set; }
      public string Email { get; set; }
      public string Password { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {
        RuleFor(x => x.Username).NotEmpty();
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).Password();
      }
    }
    public class Handler : IRequestHandler<Command, User>
    {

      private readonly DataContext _context;
      private readonly UserManager<AppUser> _userManager;
      private readonly IJwtGenerator _jwtGenerator;

      public Handler(DataContext context, UserManager<AppUser> userManager, IJwtGenerator jwtGenerator)
      {
        _jwtGenerator = jwtGenerator;
        _userManager = userManager;
        _context = context;
      }

      public async Task<User> Handle(Command request, CancellationToken cancellationToken)
      {
        if (await _context.Users.AnyAsync(x => x.Email == request.Email))
        {
          throw new RestException(HttpStatusCode.BadRequest, new { Email = "Email already exists" });
        }

        if (await _context.Users.AnyAsync(x => x.UserName == request.Username))
        {
          throw new RestException(HttpStatusCode.BadRequest, new { Username = "Username already exists" });
        }

        var user = new AppUser
        {
          FirstName = request.FirstName,
          LastName = request.LastName,
          PhoneNumber = request.PhoneNumber,
          isSupervisor = request.isSupervisor,
          Email = request.Email,
          UserName = request.Username
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (result.Succeeded)
        {
          return new User
          {
            Token = _jwtGenerator.CreateToken(user),
            Username = user.UserName,
            FirstName = request.FirstName,
            LastName = request.LastName,
            PhoneNumber = request.PhoneNumber,
            isSupervisor = request.isSupervisor,
          };
        }

        throw new Exception("Problem creating user");
      }
    }
  }
}