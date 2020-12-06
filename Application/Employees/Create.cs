using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Employees
{
  public class Create
  {
    public class Command : IRequest
    {
      public Guid Id { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string Telephone { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
      }
    }

    public class Handler : IRequestHandler<Command>
    {
      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        _context = context;
      }

      public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
      {
        var employee = new Employee
        {
          Id = request.Id,
          FirstName = request.FirstName,
          LastName = request.LastName,
          Telephone = request.Telephone
        };

        _context.Employees.Add(employee);
        var success = await _context.SaveChangesAsync() > 0;

        if (success)
        {
          return Unit.Value;
        }

        throw new Exception("Problem saving changes");
      }
    }
  }
}