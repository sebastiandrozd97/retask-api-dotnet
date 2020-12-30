using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Users;
using Application.Users.Commands;
using Application.Users.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  public class UsersController : BaseController
  {
    [HttpGet]
    public async Task<ActionResult<List<UserDto>>> List()
    {
      return await Mediator.Send(new List.Query());
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<ActionResult<User>> Login(Login.Query query)
    {
      return await Mediator.Send(query);
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<ActionResult<User>> Register(Register.Command command)
    {
      return await Mediator.Send(command);
    }

    [HttpGet("current")]
    public async Task<ActionResult<UserDto>> CurrentUser()
    {
      return await Mediator.Send(new CurrentUser.Query());
    }
  }
}