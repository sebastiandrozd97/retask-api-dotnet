using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Notifications.Queries
{
  public class List
  {
    public class Query : IRequest<List<NotificationDto>> { }

    public class Handler : IRequestHandler<Query, List<NotificationDto>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;
      }

      public async Task<List<NotificationDto>> Handle(Query request, CancellationToken cancellationToken)
      {
        var notifications = await _context.Notifications.ToListAsync();

        return _mapper.Map<List<Notification>, List<NotificationDto>>(notifications);
      }
    }
  }
}