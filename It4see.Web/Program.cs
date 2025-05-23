using System.Text;

using It4see.Application;
using It4see.Application.SensorCategories;
using It4see.Persistence;
using It4see.Persistence.Base;
using It4see.Persistence.Repositories;
using It4see.Web.Mapping;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace It4see.Web;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Logging.AddConsole();

        // Add services to the container.
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(swaggerGenOptions =>
        {
            swaggerGenOptions.AddSecurityDefinition(
                "Bearer",
                new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization Header using Bearer Scheme.",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

            swaggerGenOptions.AddSecurityRequirement(
                new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
        });

        builder.Services.AddAutoMapper(typeof(SensorProfile).Assembly);

        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateSensorCategoryCommandHandler>());

        builder.Services.AddDbContext<SensorsDatabaseContext>(options => options.UseSqlServer(
            builder.Configuration.GetConnectionString("SensorsDatabase")));

        builder.Services.AddScoped<ISensorCategoryRepository, SensorCategoryRepository>();
        builder.Services.AddScoped<ISensorRepository, SensorRepository>();

        builder.Services.AddExceptionHandler<CustomExceptionHandler>();

        builder.Services.Configure<SmtpSettings>(smtpSettings => builder.Configuration.GetSection("SmtpSettings").Bind(smtpSettings));

        var jwtSettings = builder.Configuration.GetSection("JwtSettings");
        var secretKey = jwtSettings["SecretKey"];

        builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!))
                };
            });

        builder.Services.AddAuthorization();

        WebApplication app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseMiddleware<ExceptionHandlingMiddleware>();

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}