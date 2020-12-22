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

namespace Application.Clients.Commands
{
  public class Edit
  {
    public class Command : IRequest<ClientDto>
    {
      public Guid Id { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string PhoneNumber { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
      }
    }

    public class Handler : IRequestHandler<Command, ClientDto>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;
      }

      public async Task<ClientDto> Handle(Command request, CancellationToken cancellationToken)
      {
        var client = await _context.Clients.FindAsync(request.Id);

        if (client == null)
        {
          throw new RestException(HttpStatusCode.NotFound, new { client = "Not found" });
        }

        client.FirstName = request.FirstName ?? client.FirstName;
        client.LastName = request.LastName ?? client.LastName;
        client.PhoneNumber = request.PhoneNumber ?? client.PhoneNumber;

        var success = await _context.SaveChangesAsync() > 0;

        if (success)
        {
          return _mapper.Map<Client, ClientDto>(client);
        }

        throw new Exception("Problem saving changes");
      }
    }
  }
}