using System.Threading.Tasks;
using Application.WorkdayMaterials;
using Application.WorkdayMaterials.Commands;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  public class WorkdayMaterialsController : BaseController
  {
    [HttpPost]
    public async Task<ActionResult<WorkdayMaterialDto>> Create(Create.Command command)
    {
      return await Mediator.Send(command);
    }
  }
}