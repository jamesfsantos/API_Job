using Jobs.Api.Common.Dtos;
using Jobs.Api.Jobs.Dtos;
using Jobs.Core.Models;
using Jobs.Core.Repositories;

namespace Jobs.Api.Jobs.Mappers;
public interface IJobMapper
{
    JobSummaryResponse ToSummaryResponse(Job job);
    JobDetailResponse ToDetailResponse(Job job);
    PagedResponse<JobSummaryResponse> ToPagedSummaryResponse(PagedResult<Job> pagedResult);
    Job ToModel(JobRequest jobRequest);
    Job ToModel(object jobRequest);
}