namespace Ops.API.Middleware
{
    public class MyMiddlewareTwo
    {
        private readonly RequestDelegate _next;

        public MyMiddlewareTwo(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ILogger<MyMiddlewareTwo> logger)
        {
            logger.LogInformation("MyMiddlewareTwo - Before next middleware");
            //Console.WriteLine("MyMiddlewareTwo - Before next middleware");
            await _next(context);
            logger.LogInformation("MyMiddlewareTwo - After next middleware");
            //Console.WriteLine("MyMiddlewareTwo - After next middleware");
        }

    }
}
