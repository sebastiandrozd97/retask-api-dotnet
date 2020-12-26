using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Workplaces.Queries
{
  public class Details
  {
    public class Query : IRequest<WorkplaceDto>
    {
      public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, WorkplaceDto>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;
      }

      public async Task<WorkplaceDto> Handle(Query request, CancellationToken cancellationToken)
      {
        var workplace = await _context.Workplaces.FindAsync(request.Id);

        if (workplace == null)
        {
          throw new RestException(HttpStatusCode.NotFound, new { workplace = "Not found" });
        }

        return _mapper.Map<Workplace, WorkplaceDto>(workplace);
      }
    }
  }
}