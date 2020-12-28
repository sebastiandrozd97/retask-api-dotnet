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

namespace Application.Workdays.Commands
{
  public class Create
  {
    public class Command : IRequest<WorkdayDto>
    {
      public string Task { get; set; }
      public DateTime Date { get; set; }
      public string WorkingFrom { get; set; }
      public string WorkingTo { get; set; }
      public double Worktime { get; set; }
      public string AdditionalInfo { get; set; }
      public string UserId { get; set; }
      public Guid WorkplaceId { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {
        RuleFor(x => x.Date).NotEmpty();
        RuleFor(x => x.Task).NotEmpty();
      }
    }

    public class Handler : IRequestHandler<Command, WorkdayDto>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;
      }

      public async Task<WorkdayDto> Handle(Command request, CancellationToken cancellationToken)
      {
        var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == request.UserId);

        if (user == null)
        {
          throw new RestException(HttpStatusCode.NotFound, new { user = "Not found" });
        }

        var workplace = await _context.Workplaces.SingleOrDefaultAsync(x => x.Id == request.WorkplaceId);

        if (workplace == null)
        {
          throw new RestException(HttpStatusCode.NotFound, new { workplace = "Not found" });
        }

        var workday = new Workday
        {
          Task = request.Task,
          Date = request.Date,
          WorkingFrom = request.WorkingFrom,
          WorkingTo = request.WorkingTo,
          Worktime = request.Worktime,
          AdditionalInfo = request.AdditionalInfo,
          Workplace = workplace,
          Worker = user,
        };

        await _context.Workdays.AddAsync(workday);

        var success = await _context.SaveChangesAsync() > 0;

        if (success)
        {
          return _mapper.Map<Workday, WorkdayDto>(workday);
        }

        throw new Exception("Problem saving changes");
      }
    }
  }
}