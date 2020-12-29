using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Notifications.Commands
{
  public class Edit
  {
    public class Command : IRequest<NotificationDto>
    {
      public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Command, NotificationDto>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;
      }

      public async Task<NotificationDto> Handle(Command request, CancellationToken cancellationToken)
      {
        var notification = await _context.Notifications.FindAsync(request.Id);

        if (notification == null)
        {
          throw new RestException(HttpStatusCode.NotFound, new { notification = "Not found" });
        }

        notification.IsSeen = !notification.IsSeen;

        var success = await _context.SaveChangesAsync() > 0;

        if (success)
        {
          return _mapper.Map<Notification, NotificationDto>(notification);
        }

        throw new Exception("Problem saving changes");
      }
    }
  }
}