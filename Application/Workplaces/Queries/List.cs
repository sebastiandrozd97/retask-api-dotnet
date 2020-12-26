using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Workplaces.Queries
{
  public class List
  {
    public class Query : IRequest<List<WorkplaceDto>> { }

    public class Handler : IRequestHandler<Query, List<WorkplaceDto>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;
      }

      public async Task<List<WorkplaceDto>> Handle(Query request, CancellationToken cancellationToken)
      {
        var workplaces = await _context.Workplaces.ToListAsync();

        return _mapper.Map<List<Workplace>, List<WorkplaceDto>>(workplaces);
      }
    }
  }
}