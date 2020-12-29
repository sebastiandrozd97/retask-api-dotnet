using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Notifications.Queries
{
  public class Details
  {
    public class Query : IRequest<NotificationDto>
    {
      public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, NotificationDto>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;
      }

      public async Task<NotificationDto> Handle(Query request, CancellationToken cancellationToken)
      {
        var notification = await _context.Notifications.FindAsync(request.Id);

        if (notification == null)
        {
          throw new RestException(HttpStatusCode.NotFound, new { notification = "Not found" });
        }

        return _mapper.Map<Notification, NotificationDto>(notification);
      }
    }
  }
}