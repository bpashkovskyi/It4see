using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using It4see.Domain;

using MediatR;

using Microsoft.IdentityModel.Tokens;

namespace It4see.Application.Login;

public class LogicCommandHandler : IRequestHandler<LoginCommand, string>
{
    private readonly List<Person> _people =
    [
        new Person("tom@gmail.com", "12345"),
        new Person("bob@gmail.com", "55555")
    ];

    public Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        Person person = _people.FirstOrDefault(p => p.Email == request.Person.Email && p.Password == request.Person.Password);

        if (person is null)
        {
            return Task.FromResult((string)null);
        }

        List<Claim> claims = new List<Claim> { new(ClaimTypes.Name, person.Email) };

        JwtSecurityToken jwt = new JwtSecurityToken(
            issuer: AuthOptions.Issuer,
            audience: AuthOptions.Audience,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

        string encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        return Task.FromResult(encodedJwt);
    }
}