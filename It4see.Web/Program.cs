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

        builder.Services.AddAuthorization();
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = AuthOptions.Issuer,
                ValidateAudience = true,
                ValidAudience = AuthOptions.Audience,
                ValidateLifetime = true,
                IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                ValidateIssuerSigningKey = true,
            };
        });

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

        WebApplication app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        ////app.UseMiddleware<ExceptionHandlingMiddleware>();

        app.UseHttpsRedirection();
        app.UseExceptionHandler(_ => { });

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}