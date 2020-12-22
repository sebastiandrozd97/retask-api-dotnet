using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Clients.Queries
{
  public class List
  {
    public class Query : IRequest<List<ClientDto>> { }

    public class Handler : IRequestHandler<Query, List<ClientDto>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;
      }

      public async Task<List<ClientDto>> Handle(Query request, CancellationToken cancellationToken)
      {
        var clients = await _context.Clients.ToListAsync();

        return _mapper.Map<List<Client>, List<ClientDto>>(clients);
      }
    }
  }
}