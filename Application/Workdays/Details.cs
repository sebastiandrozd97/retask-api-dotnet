using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Domain;
using MediatR;
using Persistence;

namespace Application.Workdays
{
  public class Details
  {
    public class Query : IRequest<Workday>
    {
      public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Workday>
    {
      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        _context = context;
      }

      public async Task<Workday> Handle(Query request, CancellationToken cancellationToken)
      {
        var workday = await _context.Workdays.FindAsync(request.Id);

        if (workday == null)
        {
          throw new RestException(HttpStatusCode.NotFound, new { workday = "Not found" });
        }

        return workday;
      }
    }
  }
}