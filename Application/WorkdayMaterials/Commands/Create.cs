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

namespace Application.WorkdayMaterials.Commands
{
  public class Create
  {
    public class Command : IRequest<WorkdayMaterialDto>
    {
      public string Item { get; set; }
      public double Price { get; set; }
      public DateTime Date { get; set; }
      public string WorkerId { get; set; }
      public Guid WorkplaceId { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {
        RuleFor(x => x.Item).NotEmpty();
        RuleFor(x => x.Price).NotEmpty();
        RuleFor(x => x.Date).NotEmpty();
        RuleFor(x => x.WorkerId).NotEmpty();
        RuleFor(x => x.WorkplaceId).NotEmpty();
      }
    }

    public class Handler : IRequestHandler<Command, WorkdayMaterialDto>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;
      }

      public async Task<WorkdayMaterialDto> Handle(Command request, CancellationToken cancellationToken)
      {
        var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == request.WorkerId);

        if (user == null)
        {
          throw new RestException(HttpStatusCode.NotFound, new { user = "Not found" });
        }

        var workplace = await _context.Workplaces.SingleOrDefaultAsync(x => x.Id == request.WorkplaceId);

        if (workplace == null)
        {
          throw new RestException(HttpStatusCode.NotFound, new { workplace = "Not found" });
        }

        var workdayMaterial = new WorkdayMaterial
        {
          Item = request.Item,
          Price = request.Price,
          Date = request.Date,
          Workplace = workplace,
          Worker = user,
        };

        await _context.WorkdayMaterials.AddAsync(workdayMaterial);

        var success = await _context.SaveChangesAsync() > 0;

        if (success)
        {
          return _mapper.Map<WorkdayMaterial, WorkdayMaterialDto>(workdayMaterial);
        }

        throw new Exception("Problem saving changes");
      }
    }
  }
}