using It4see.Application.Categories;
using It4see.Persistence;
using It4see.Persistence.Base;
using It4see.Web.Mapping;

using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace It4see.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddAutoMapper(typeof(ProductProfile).Assembly);

        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateCategoryCommandHandler>());

        builder.Services.AddDbContext<ShopDatabaseContext>(options => options.UseSqlServer(
            builder.Configuration.GetConnectionString("ShopDatabase")));

        builder.Services.AddScoped<ICategoryRepository, ICategoryRepository>();


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}