using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Notifications;
using Application.Notifications.Commands;
using Application.Notifications.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  public class NotificationsController : BaseController
  {
    [HttpGet]
    public async Task<ActionResult<List<NotificationDto>>> List()
    {
      return await Mediator.Send(new List.Query());
    }

    [HttpPost]
    public async Task<ActionResult<NotificationDto>> Create(Create.Command command)
    {
      return await Mediator.Send(command);
    }
  }
}