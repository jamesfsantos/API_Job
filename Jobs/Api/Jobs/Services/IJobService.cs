using Jobs.Api.Common.Dtos;
using Jobs.Api.Jobs.Dtos;
using Jobs.Core.Models;

namespace Jobs.Api.Jobs.Services;

public interface IJobService
{
    ICollection<JobSummaryResponse> FindAll();
    PagedResponse<JobSummaryResponse> FindAll(int page, int size);
    JobDetailResponse FindById(int id);
    JobDetailResponse Create(JobRequest jobRequest);
    JobDetailResponse UpdateById(int id, JobRequest jobRequest);
    void DeleteById(int id);
}