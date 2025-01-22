using MedHelp.Api;

namespace itLabs.Api;

public class Program
{
  public static async Task Main(string[] args)
  {
    IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
      
    var builder = WebApplication.CreateBuilder(args);
      
    var startup = new Startup(builder.Configuration);

    startup.ConfigureServices(builder.Services);
    
    builder.Services.AddOpenApi();

    var app = builder.Build();
      
    startup.Configure(app);
    
    if (app.Environment.IsDevelopment())
    {
      app.MapOpenApi();
    }
    
    app.UseHttpsRedirection();
    
    await app.RunAsync();
  }
}