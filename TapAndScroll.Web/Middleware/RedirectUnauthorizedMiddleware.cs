namespace TapAndScroll.Web.Middleware
{
    public class RedirectUnauthorizedMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);

            if (context.Response.StatusCode == StatusCodes.Status401Unauthorized)
            {
                context.Response.Redirect("/Authorize/Login");
            }
        }
    }

    public static class RedirectUnauthorizedMiddlewareExtensions
    {
        public static IApplicationBuilder UseRedirectUnauthorized(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RedirectUnauthorizedMiddleware>();
        }
    }
}
