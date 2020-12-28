using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.WorkdayMaterials;
using Application.WorkdayMaterials.Commands;
using Application.WorkdayMaterials.Queries;
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
  }
}