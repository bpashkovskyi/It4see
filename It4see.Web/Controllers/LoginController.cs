using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using It4see.Application.Login;
using It4see.Domain;

using MediatR;

namespace It4see.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private IMediator mediator;

    public LoginController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Login(Person person)
    {
        var loginCommand = new LoginCommand
        {
            Person = person
        };

        var jwtToken = await this.mediator.Send(loginCommand);
        if (jwtToken == null)
        {
            return Unauthorized();
        }

        return Ok(jwtToken);
    }
}