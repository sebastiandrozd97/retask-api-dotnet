using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using MediatR;
using Persistence;

namespace Application.WorkdayMaterials.Commands
{
  public class Delete
  {
    public class Command : IRequest
    {
      public Guid Id { get; set; }
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
        var workdayMaterial = await _context.WorkdayMaterials.FindAsync(request.Id);

        if (workdayMaterial == null)
        {
          throw new RestException(HttpStatusCode.NotFound, new { workdayMaterial = "Not found" });
        }

        _context.Remove(workdayMaterial);

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