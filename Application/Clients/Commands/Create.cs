using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Clients.Commands
{
  public class Create
  {
    public class Command : IRequest<ClientDto>
    {
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string PhoneNumber { get; set; }
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
        var client = new Client
        {
          FirstName = request.FirstName,
          LastName = request.LastName,
          PhoneNumber = request.PhoneNumber,
        };

        _context.Clients.Add(client);

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