using Jobs.Api.Common.Assemblers;
using Jobs.Api.Common.Dtos;
using Jobs.Api.Jobs.Dtos;

namespace Jobs.Api.Jobs.Assemblers;

public class JobSummaryAssembler : IAssembler<JobSummaryResponse>
{
    private readonly LinkGenerator _linkGenerator;

    public JobSummaryAssembler(LinkGenerator linkGenerator)
    {
        _linkGenerator = linkGenerator;
    }

    public JobSummaryResponse ToResource(JobSummaryResponse resource, HttpContext context)
    {
        var selfLink = new LinkResponse(
            _linkGenerator.GetUriByName(context, "FindJobById", new { Id = resource.Id}),
            "GET",
            "self"

        );
        var updateLink = new LinkResponse(
            _linkGenerator.GetUriByName(context, "UpdateJobById", new { Id = resource.Id}),
            "PUT",
            "update"
        );
        var deleteLink = new LinkResponse(
            _linkGenerator.GetUriByName(context, "DeleteJobById", new { Id = resource.Id}),
            "DELETE",
            "delete"
        );
        resource.AddLinks(selfLink, updateLink, deleteLink);
        return resource;
    }
}