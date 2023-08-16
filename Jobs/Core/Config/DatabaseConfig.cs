using Jobs.Core.Data.Contexts;

namespace Jobs.Core.Config;

public static class DatabaseConfig
{
    public static void RegisterDataBase(this IServiceCollection services)
    {
        services.AddDbContext<JobsDbContext>();
    }
}