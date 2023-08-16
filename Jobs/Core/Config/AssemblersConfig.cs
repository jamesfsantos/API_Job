using Jobs.Api.Common.Assemblers;
using Jobs.Api.Jobs.Assemblers;
using Jobs.Api.Jobs.Dtos;

namespace Jobs.Core.Config;

public static class AssemblersConfig
{
    public static void RegisterAssemblers(this IServiceCollection services)
    {
        services.AddScoped<IAssembler<JobSummaryResponse>, JobSummaryAssembler>();
        services.AddScoped<IAssembler<JobDetailResponse>, JobDetailAssembler>();
        services.AddScoped<IPagedAssembler<JobSummaryResponse>, JobSummaryPagedAssembler>();
    }
}