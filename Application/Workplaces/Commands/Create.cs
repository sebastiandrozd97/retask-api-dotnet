using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Workplaces.Commands
{
  public class Create
  {
    public class Command : IRequest<WorkplaceDto>
    {
      public string Name { get; set; }
      public string City { get; set; }
      public string Street { get; set; }
      public Guid ClientId { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.City).NotEmpty();
        RuleFor(x => x.ClientId).NotEmpty();
      }
    }

    public class Handler : IRequestHandler<Command, WorkplaceDto>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;
      }

      public async Task<WorkplaceDto> Handle(Command request, CancellationToken cancellationToken)
      {
        var client = await _context.Clients.FindAsync(request.ClientId);

        var workplace = new Workplace
        {
          Name = request.Name,
          City = request.City,
          Street = request.Street,
          IsOpen = true,
          Client = client,
          Notifications = new List<Notification>(),
          Workdays = new List<Workday>(),
          WorkdayMaterials = new List<WorkdayMaterial>(),
        };

        await _context.Workplaces.AddAsync(workplace);

        var success = await _context.SaveChangesAsync() > 0;

        if (success)
        {
          return _mapper.Map<Workplace, WorkplaceDto>(workplace);
        }

        throw new Exception("Problem saving changes");
      }
    }
  }
}