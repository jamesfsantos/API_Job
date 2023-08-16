using Jobs.Api.Jobs.Mappers;

namespace Jobs.Core.Config;

public static class MappersConfig
{
    public static void RegisterMappers(this IServiceCollection services)
    {
        services.AddScoped<IJobMapper, JobMapper>();
    }
}