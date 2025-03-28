using Microsoft.AspNetCore.Mvc;
using It4see.Application.Login;
using It4see.Domain;

using MediatR;

using Microsoft.Extensions.Options;

namespace It4see.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController(
    IMediator mediator,
    IOptionsSnapshot<SmtpSettings> options,
    ILogger<LoginController> logger)
    : ControllerBase
{
    private SmtpSettings options = options.Value;

    [HttpGet]
    public IActionResult Config()
    {
        return this.Ok(options.Host);
    }

    [HttpPost]
    public async Task<IActionResult> Login(Person person)
    {
        logger.LogDebug($"Person with email {person.Email} logged to system");

        logger.LogDebug("Person with email {Email} logged to system", person.Email);


        var loginCommand = new LoginCommand
        {
            Person = person
        };

        var jwtToken = await mediator.Send(loginCommand);
        if (jwtToken == null)
        {
            return Unauthorized();
        }

        return Ok(jwtToken);
    }
}