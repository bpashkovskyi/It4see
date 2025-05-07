using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using It4see.Domain;

using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace It4see.Application.Login;

public class LogicCommandHandler : IRequestHandler<LoginCommand, string>
{
    private IConfiguration configuration;

    public LogicCommandHandler(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    // Ideally we have to check if user exists in db and check password
    // But here it is skipped for simplisity
    public Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var jwtSettings = configuration.GetSection("JwtSettings");
        var secretKey = jwtSettings["SecretKey"];
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!));

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, request.UserId),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Role, "User")
        };

        var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
        );

        return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
    }
}