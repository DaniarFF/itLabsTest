using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace MedHelp.Api;

/// <summary>
///   Middleware для проверки ключей API.
/// </summary>
public class ApiKeyMiddleware
{
  private const string ApiKeyHeaderName = "x-api-key";
  private readonly RequestDelegate _next;
  private readonly string RequiredApiKey;

  public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
  {
    _next = next;
    RequiredApiKey = configuration.GetValue<string>("ApiSettings:ApiKey") ?? string.Empty;
  }

  public async Task InvokeAsync(HttpContext context)
  {
    if (context.Request.Path.StartsWithSegments("/api"))
    {
      if (!context.Request.Headers.TryGetValue(ApiKeyHeaderName, out var extractedApiKey))
      {
        context.Response.StatusCode = 401;
        await context.Response.WriteAsync("API Key was not provided.");
        return;
      }

      if (!RequiredApiKey.Equals(extractedApiKey))
      {
        context.Response.StatusCode = 403;
        await context.Response.WriteAsync("Unauthorized client.");
        return;
      }
    }

    await _next(context);
  }
}