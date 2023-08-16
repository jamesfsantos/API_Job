using Jobs.Core.Middlewares;

namespace Jobs.Core.Config;

public static class MiddlewaresConfig
{
    public static void RegisterMiddlerwares(this WebApplication app)
    {
        app.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}