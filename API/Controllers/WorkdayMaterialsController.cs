using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.WorkdayMaterials;
using Application.WorkdayMaterials.Commands;
using Application.WorkdayMaterials.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  public class WorkdayMaterialsController : BaseController
  {
    [HttpGet]
    public async Task<ActionResult<List<WorkdayMaterialDto>>> List()
    {
      return await Mediator.Send(new List.Query());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<WorkdayMaterialDto>> Details(Guid id)
    {
      return await Mediator.Send(new Details.Query { Id = id });
    }

    [HttpPost]
    public async Task<ActionResult<WorkdayMaterialDto>> Create(Create.Command command)
    {
      return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<WorkdayMaterialDto>> Edit(Guid id, Edit.Command command)
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