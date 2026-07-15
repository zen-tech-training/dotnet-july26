namespace Ops.API.Middleware
{
    public class MyMiddlewareThreeDI: IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Console.WriteLine("MyMiddlewareThreeDI - Before next middleware");
            await next(context);
            Console.WriteLine("MyMiddlewareThreeDI - After next middleware");
        }
    }
}
