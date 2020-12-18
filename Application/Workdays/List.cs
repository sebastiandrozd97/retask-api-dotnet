using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Workdays
{
  public class List
  {
    public class Query : IRequest<List<WorkdayDto>> { }

    public class Handler : IRequestHandler<Query, List<WorkdayDto>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;
      }

      public async Task<List<WorkdayDto>> Handle(Query request, CancellationToken cancellationToken)
      {
        var workdays = await _context.Workdays.ToListAsync();

        return _mapper.Map<List<Workday>, List<WorkdayDto>>(workdays);
      }
    }
  }
}