using Handbook.Server.Data;
using Handbook.Server.Services.UserService;
using Microsoft.EntityFrameworkCore;

namespace Handbook.Server;

internal class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        AddServices(builder);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        //app.Services.GetService<ApplicationContext>()?.Database.EnsureCreated();

        app.UseHttpsRedirection();

        app.UseBlazorFrameworkFiles();
        app.UseStaticFiles();

        app.UseRouting();


        app.MapRazorPages();
        app.MapControllers();
        app.MapFallbackToFile("index.html");

        app.Run();

    }

    private static void AddServices(WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<ApplicationContext>(options =>
            options.UseInMemoryDatabase(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddControllersWithViews();
        builder.Services.AddRazorPages();

        builder.Services.AddScoped<IUserService, UserService>();
    }
}