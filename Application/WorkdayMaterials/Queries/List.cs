using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.WorkdayMaterials.Queries
{
  public class List
  {
    public class Query : IRequest<List<WorkdayMaterialDto>> { }

    public class Handler : IRequestHandler<Query, List<WorkdayMaterialDto>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;
      }

      public async Task<List<WorkdayMaterialDto>> Handle(Query request, CancellationToken cancellationToken)
      {
        var workdayMaterials = await _context.WorkdayMaterials.ToListAsync();

        return _mapper.Map<List<WorkdayMaterial>, List<WorkdayMaterialDto>>(workdayMaterials);
      }
    }
  }
}