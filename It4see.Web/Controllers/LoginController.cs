using Microsoft.AspNetCore.Mvc;
using It4see.Application.Login;

using MediatR;

namespace It4see.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController(
    IMediator mediator)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Login(string userId)
    {
        LoginCommand loginCommand = new LoginCommand
        {
            UserId = userId
        };

        string jwtToken = await mediator.Send(loginCommand);
        if (jwtToken == null)
        {
            return Unauthorized();
        }

        return Ok(jwtToken);
    }
}