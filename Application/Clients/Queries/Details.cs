using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Clients.Queries
{
  public class Details
  {
    public class Query : IRequest<ClientDto>
    {
      public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, ClientDto>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;
      }

      public async Task<ClientDto> Handle(Query request, CancellationToken cancellationToken)
      {
        var client = await _context.Clients.FindAsync(request.Id);

        if (client == null)
        {
          throw new RestException(HttpStatusCode.NotFound, new { client = "Not found" });
        }

        return _mapper.Map<Client, ClientDto>(client);
      }
    }
  }
}