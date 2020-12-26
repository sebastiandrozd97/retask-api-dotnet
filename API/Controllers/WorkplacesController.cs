using System.Threading.Tasks;
using Application.Workplaces;
using Application.Workplaces.Commands;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  public class WorkplacesController : BaseController
  {
    [HttpPost]
    public async Task<ActionResult<WorkplaceDto>> Create(Create.Command command)
    {
      return await Mediator.Send(command);
    }
  }
}