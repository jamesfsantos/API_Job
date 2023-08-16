using Jobs.Api.Common.Dtos;

namespace Jobs.Api.Jobs.Dtos;

public class JobSummaryResponse : ResourseResponse
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
}