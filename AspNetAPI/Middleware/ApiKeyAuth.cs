using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Webextant.Security.Cryptography;
using Microsoft.Extensions.Primitives;
using Hanc.Common.Options;

namespace Hanc.AspNetAPI
{
    /// <summary>
    /// Adapted from concepts used here: https://blogs.msdn.microsoft.com/dotnet/2016/09/19/custom-asp-net-core-middleware-example/
    /// </summary>
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly Mac _mac;
        private readonly string _appId;
        private readonly bool _requireAuthToken;
        private readonly string _endpointPath;
        public ApiKeyMiddleware(RequestDelegate next, IOptions<SecretOptions> optionsAccessor, string path)
        {
            _next = next;
            _mac = new Mac(optionsAccessor.Value.MacSecret);
            _appId = optionsAccessor.Value.AppId;
            _requireAuthToken = optionsAccessor.Value.RequireApiAuthToken;
            _endpointPath = path;
        }

        public async Task Invoke(HttpContext context)
        {
            // If request is for api path then check the application id and auth token
            if (context.Request.Path.Value.Contains(_endpointPath))
            {
                bool _auth = false;
                bool _appIdIsValid = false;
                StringValues _clientAppId;
                StringValues _clientAuthToken;

                context.Request.Headers.TryGetValue("X-Hanc-Application-Id", out _clientAppId);
                context.Request.Headers.TryGetValue("X-Hanc-Auth-Token", out _clientAuthToken);

                if (_clientAppId == StringValues.Empty)
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Bad request");
                    return;
                }

                // check the application id
                _appIdIsValid = _clientAppId == _appId;

                // Check auth token if required
                if (_requireAuthToken)
                {
                    _auth = _clientAuthToken == _mac.GenerateToken(_clientAppId) && _appIdIsValid;
                }
                else {
                    _auth = _appIdIsValid;
                }

                if (!_auth)
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Unauthorized");
                    return;
                }
            }

            await _next.Invoke(context);
        }

    }
    public static class UserKeyValidatorsExtension
    {
        public static IApplicationBuilder UseApiKeyAuthorization(this IApplicationBuilder app, string path)
        {
            app.UseMiddleware<ApiKeyMiddleware>(path);
            return app;
        }
    }
}