using itLabs.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace itLabs.Repository;

public static class Entry
{
  public static IServiceCollection AddRepositoryIntegration(this IServiceCollection serviceCollection)
  {
    serviceCollection.AddScoped<ICustomerRepository, CustomerRepositoryMock>();

    return serviceCollection;
  }
}