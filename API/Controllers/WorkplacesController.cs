using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Workplaces;
using Application.Workplaces.Commands;
using Application.Workplaces.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  public class WorkplacesController : BaseController
  {
    [HttpGet]
    public async Task<ActionResult<List<WorkplaceDto>>> List()
    {
      return await Mediator.Send(new List.Query());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<WorkplaceDto>> Details(Guid id)
    {
      return await Mediator.Send(new Details.Query { Id = id });
    }

    [HttpPost]
    public async Task<ActionResult<WorkplaceDto>> Create(Create.Command command)
    {
      return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<WorkplaceDto>> Edit(Guid id, Edit.Command command)
    {
      command.Id = id;
      return await Mediator.Send(command);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Unit>> Delete(Guid id)
    {
      return await Mediator.Send(new Delete.Command { Id = id });
    }
  }
}