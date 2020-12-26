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

namespace Application.Workplaces.Commands
{
  public class Edit
  {
    public class Command : IRequest<WorkplaceDto>
    {
      public Guid Id { get; set; }
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
        var workplace = await _context.Workplaces.FindAsync(request.Id);

        if (workplace == null)
        {
          throw new RestException(HttpStatusCode.NotFound, new { workplace = "Not found" });
        }

        if (workplace.Client == null || workplace.Client.Id != request.ClientId)
        {
          var client = await _context.Clients.SingleOrDefaultAsync(x => x.Id == request.ClientId);
          workplace.Client = client;
        }

        workplace.Name = request.Name ?? workplace.Name;
        workplace.City = request.City ?? workplace.City;
        workplace.Street = request.Street ?? workplace.Street;

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