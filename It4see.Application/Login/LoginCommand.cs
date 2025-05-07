using It4see.Domain;

using MediatR;

namespace It4see.Application.Login;

public class LoginCommand : IRequest<string>
{
    public string UserId { get; set; }
}