using Jobs.Core.Repositories.Jobs;

namespace Jobs.Core.Config;

public static class RepositoriesConfig
{
    public static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IJobRepository, JobRepository>();
    }
}