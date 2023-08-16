using Jobs.Api.Common.Dtos;

namespace Jobs.Api.Common.Assemblers
{
    public interface IPagedAssembler<R> where R : ResourseResponse
    {
        PagedResponse<R> ToPagedResource(PagedResponse<R> pagedResource, HttpContext context);
    }
}
