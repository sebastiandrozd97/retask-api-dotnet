using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Workdays
{
  public class Create
  {
    public class Command : IRequest<WorkdayDto>
    {
      public string Task { get; set; }
      public string UserId { get; set; }
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

        var workday = new Workday
        {
          Task = request.Task,
          Worker = user,
        };

        _context.Workdays.Add(workday);

        var success = await _context.SaveChangesAsync() > 0;

        if (success)
        {
          return _mapper.Map<WorkdayDto>(workday);
        }

        throw new Exception("Problem saving changes");
      }
    }
  }
}