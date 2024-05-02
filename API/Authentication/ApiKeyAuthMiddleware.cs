namespace API.Authentication
{
    public class ApiKeyAuthMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiKeyAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if(!context.Request.Headers.TryGetValue("API_KEY", out var expectedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("API Key missing");
                return;
            }
            var apiKey = Environment.GetEnvironmentVariable("API_KEY");
            if(apiKey == null)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("API Key not provided by server");
                return;
            }
            else if (!apiKey.Equals(expectedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Invalid API Key");
                return;
            }
            await _next(context);
        }
    }
}
