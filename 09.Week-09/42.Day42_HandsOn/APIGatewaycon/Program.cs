using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace APIGatewaycon
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Load ocelot.json
            builder.Configuration
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            // Add Ocelot
            builder.Services.AddOcelot(builder.Configuration);

            var app = builder.Build();

           
            app.MapGet("/", () => "Gateway Working ✅");

            
            await app.UseOcelot();

            app.Run();
        }
    }
}