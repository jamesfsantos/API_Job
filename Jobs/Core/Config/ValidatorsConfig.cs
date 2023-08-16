using FluentValidation;
using Jobs.Api.Jobs.Dtos;
using Jobs.Api.Jobs.Validots;

namespace Jobs.Core.Config;

public static class ValidatorsConfig
{
    public static void RegisterValidators (this IServiceCollection services)
    {
        services.AddScoped<IValidator<JobRequest>, JobRequestValidator>();
    }
}