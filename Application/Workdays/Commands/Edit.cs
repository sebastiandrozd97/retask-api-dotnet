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
  public class Edit
  {
    public class Command : IRequest<WorkdayDto>
    {
      public Guid Id { get; set; }
      public string Task { get; set; }
      public DateTime Date { get; set; }
      public string WorkingFrom { get; set; }
      public string WorkingTo { get; set; }
      public double Worktime { get; set; }
      public string AdditionalInfo { get; set; }
      public string WorkerId { get; set; }
      public Guid WorkplaceId { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {
        RuleFor(x => x.Task).NotEmpty();
        RuleFor(x => x.Date).NotEmpty();
        RuleFor(x => x.Worktime).NotEmpty();
        RuleFor(x => x.WorkerId).NotEmpty();
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
        var workday = await _context.Workdays.FindAsync(request.Id);

        if (workday == null)
        {
          throw new RestException(HttpStatusCode.NotFound, new { workday = "Not found" });
        }

        if (workday.Workplace == null || workday.Workplace.Id != request.WorkplaceId)
        {
          var workplace = await _context.Workplaces.SingleOrDefaultAsync(x => x.Id == request.WorkplaceId);
          workday.Workplace = workplace;
        }

        if (workday.Worker == null || workday.Worker.Id != request.WorkerId)
        {
          var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == request.WorkerId);
          workday.Worker = user;
        }

        workday.Task = request.Task ?? workday.Task;
        workday.Date = request.Date;
        workday.WorkingFrom = request.WorkingFrom ?? workday.WorkingFrom;
        workday.WorkingTo = request.WorkingTo ?? workday.WorkingTo;
        workday.Worktime = request.Worktime;
        workday.AdditionalInfo = request.AdditionalInfo ?? workday.AdditionalInfo;

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