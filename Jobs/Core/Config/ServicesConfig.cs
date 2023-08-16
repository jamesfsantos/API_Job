using Jobs.Api.Jobs.Services;

namespace Jobs.Core.Config;

public static class ServicesConfig
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IJobService, JobService>();
    }
}