using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Notifications.Commands
{
  public class Create
  {
    public class Command : IRequest<NotificationDto>
    {
      public string Action { get; set; }
      public DateTime Date { get; set; }
      public string WorkerId { get; set; }
      public Guid WorkplaceId { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {
        RuleFor(x => x.Action).NotEmpty();
        RuleFor(x => x.Date).NotEmpty();
        RuleFor(x => x.WorkerId).NotEmpty();
        RuleFor(x => x.WorkplaceId).NotEmpty();
      }
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
        var worker = await _context.Users.SingleOrDefaultAsync(x => x.Id == request.WorkerId);

        if (worker == null)
        {
          throw new RestException(HttpStatusCode.NotFound, new { worker = "Not found" });
        }

        var workplace = await _context.Workplaces.SingleOrDefaultAsync(x => x.Id == request.WorkplaceId);

        if (workplace == null)
        {
          throw new RestException(HttpStatusCode.NotFound, new { workplace = "Not found" });
        }

        var notification = new Notification
        {
          Action = request.Action,
          Date = request.Date,
          Workplace = workplace,
          Worker = worker,
        };

        await _context.Notifications.AddAsync(notification);

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