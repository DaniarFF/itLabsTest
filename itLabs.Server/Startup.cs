using itLabs.Core;
using itLabs.Repository;
using MedHelp.Api;
using Microsoft.OpenApi.Models;

namespace itLabs.Api;

public class Startup
{
  private IConfiguration Configuration { get; }

  public Startup(IConfiguration configuration)
  {
    Configuration = configuration;
  }
  
  public void ConfigureServices(IServiceCollection services)
  {
    services.AddControllers();

    services.AddRepositoryIntegration();
    
    services.AddCoreIntegration();
  }

  public void Configure(IApplicationBuilder app)
  {
    app.UseRouting();
    app.UseMiddleware<ApiKeyMiddleware>();

    app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
  }
}