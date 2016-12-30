using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Hanc.AspNetAPI
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _apiKey;
        public ApiKeyMiddleware(RequestDelegate next, IOptions<SecretOptions> optionsAccessor)
        {
            _next = next;
            _apiKey = optionsAccessor.Value.ApiKey;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.Headers.Keys.Contains("ApiKey"))
            {
                context.Response.StatusCode = 400; //Bad Request                
                await context.Response.WriteAsync("Bad Request");
                return;
            }
            else
            {
                if (context.Request.Headers["ApiKey"] != _apiKey)
                {
                    context.Response.StatusCode = 401; //UnAuthorized
                    await context.Response.WriteAsync("Unauthorized");
                    return;
                }
            }

            await _next.Invoke(context);
        }

    }
    public static class UserKeyValidatorsExtension
    {
        public static IApplicationBuilder UseApiKeyAuthorization(this IApplicationBuilder app)
        {
            app.UseMiddleware<ApiKeyMiddleware>();
            return app;
        }
    }
}