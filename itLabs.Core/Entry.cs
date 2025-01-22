using itLabs.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace itLabs.Core;

public static class Entry
{
  public static IServiceCollection AddCoreIntegration(this IServiceCollection serviceCollection)
  {
    serviceCollection.AddScoped<ICustomerService, CustomerService>();

    return serviceCollection;
  }
}