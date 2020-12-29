using System.Threading.Tasks;
using Application.Notifications;
using Application.Notifications.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  public class NotificationsController : BaseController
  {
    [HttpPost]
    public async Task<ActionResult<NotificationDto>> Create(Create.Command command)
    {
      return await Mediator.Send(command);
    }
  }
}