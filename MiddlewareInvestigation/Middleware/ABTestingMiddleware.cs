namespace MiddlewareInvestigation.Middleware
{
    public class ABTestingMiddleware
    {
        private RequestDelegate _next;
        private ILogger<ABTestingMiddleware> _logger;

        public ABTestingMiddleware(RequestDelegate next, ILogger<ABTestingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public Task Invoke(HttpContext context)
        {
            _logger.LogInformation("***AB Testing Middleware Activated");
            string path = context.Request.Path;

            if (path.StartsWith("/Marketing/Index"))
            {
                Random rg = new Random();
                int r = rg.Next(100);
                if (r < 50)
                {
                    context.Response.Redirect("/Marketing/Message1");
                }
                else
                {
                    context.Response.Redirect("/Marketing/Message2");
                }
            }
            return _next(context);
        }
    }

    public static class ABTestingMiddlewareExtensions
    {
        public static IApplicationBuilder UseABTesting(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ABTestingMiddleware>();
        }
    }
}
