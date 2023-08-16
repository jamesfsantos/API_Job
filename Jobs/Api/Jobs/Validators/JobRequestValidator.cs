using FluentValidation;
using Jobs.Api.Jobs.Dtos;

namespace Jobs.Api.Jobs.Validots;

public class JobRequestValidator : AbstractValidator<JobRequest>
{
    public JobRequestValidator()
    {
        RuleFor(j => j.Title).NotEmpty().OverridePropertyName("title");
        RuleFor(j => j.Salary).GreaterThan(0).OverridePropertyName("salary");
        RuleFor(j => j.Requirements).NotEmpty().OverridePropertyName("requirements");
    }
}
