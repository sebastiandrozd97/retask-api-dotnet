using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Workdays
{
  public class List
  {
    public class Query : IRequest<List<Workday>> { }

    public class Handler : IRequestHandler<Query, List<Workday>>
    {
      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        _context = context;
      }

      public async Task<List<Workday>> Handle(Query request, CancellationToken cancellationToken)
      {
        var workdays = await _context.Workdays.ToListAsync();

        return workdays;
      }
    }
  }
}