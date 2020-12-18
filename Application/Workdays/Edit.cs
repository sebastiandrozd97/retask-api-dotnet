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

namespace Application.Workdays
{
  public class Edit
  {
    public class Command : IRequest<WorkdayDto>
    {
      public Guid Id { get; set; }
      public string Task { get; set; }
      public string UserId { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {
        RuleFor(x => x.Task).NotEmpty();
        RuleFor(x => x.UserId).NotEmpty();
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

        if (workday.Worker == null || workday.Worker.Id != request.UserId)
        {
          var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == request.UserId);
          workday.Worker = user;
        }

        workday.Task = request.Task ?? workday.Task;

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