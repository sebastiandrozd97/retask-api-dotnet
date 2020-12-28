using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.WorkdayMaterials.Queries
{
  public class Details
  {
    public class Query : IRequest<WorkdayMaterialDto>
    {
      public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, WorkdayMaterialDto>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      private readonly IUserAccessor _userAccessor;
      public Handler(DataContext context, IMapper mapper, IUserAccessor userAccessor)
      {
        _userAccessor = userAccessor;
        _mapper = mapper;
        _context = context;
      }

      public async Task<WorkdayMaterialDto> Handle(Query request, CancellationToken cancellationToken)
      {
        var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == _userAccessor.GetCurrentUsername());
        var workdayMaterial = await _context.WorkdayMaterials.FindAsync(request.Id);

        if (workdayMaterial == null)
        {
          throw new RestException(HttpStatusCode.NotFound, new { workdayMaterial = "Not found" });
        }

        if (workdayMaterial.Worker.Id != user.Id && !user.isSupervisor)
        {
          throw new RestException(HttpStatusCode.Unauthorized, new { workday = "Not authorized" });
        }

        return _mapper.Map<WorkdayMaterial, WorkdayMaterialDto>(workdayMaterial);
      }
    }
  }
}