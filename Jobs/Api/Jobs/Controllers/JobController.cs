using Flurl.Http;
using Jobs.Api.Common.Assemblers;
using Jobs.Api.Common.Dtos;
using Jobs.Api.Jobs.Assemblers;
using Jobs.Api.Jobs.Dtos;
using Jobs.Api.Jobs.Services;
using Microsoft.AspNetCore.Mvc;

namespace Jobs.Api.Jobs.Controllers;

[ApiController]
[Route("/api/jobs")]
public class JobControler : ControllerBase
{
    private readonly IJobService _jobService;
    private readonly IPagedAssembler<JobSummaryResponse> _jobSummaryPagedAssembler;
    private readonly IAssembler<JobDetailResponse> _jobDetailAssembler;

    public JobControler(IJobService jobService, IPagedAssembler<JobSummaryResponse> jobSummaryPagedAssembler, IAssembler<JobDetailResponse> jobDetailAssembler)
    {
        _jobService = jobService;
        _jobSummaryPagedAssembler = jobSummaryPagedAssembler;
        _jobDetailAssembler = jobDetailAssembler;
    }


    

    [HttpGet(Name = "FindAlljobs")]
    public IActionResult FindAll([FromQuery]int page,[FromQuery] int size)
    {
        var body = _jobService.FindAll(page, size);
        
        return Ok(_jobSummaryPagedAssembler.ToPagedResource(body, HttpContext));
    }

    [HttpGet("{id}", Name = "FindJobById")]
    public IActionResult FindById(int id)
    {
        var body = _jobService.FindById(id);
        return Ok(_jobDetailAssembler.ToResource(body, HttpContext));
    }


    [HttpPost(Name = "CreateJob")]
    public IActionResult Create([FromBody] JobRequest jobRequest)
    {
        var body = _jobService.Create(jobRequest);
        return CreatedAtAction(
            nameof(FindById), 
            new { Id = body.Id }, 
            _jobDetailAssembler.ToResource(body, HttpContext)
        );
    }

    [HttpPut("{id}", Name = "UpdateJobById")]
    public IActionResult UpdateById([FromRoute] int id, [FromBody] JobRequest jobRequest)
    {
        var body = _jobService.UpdateById(id, jobRequest);
        return Ok(_jobDetailAssembler.ToResource(body, HttpContext));
    }

    [HttpDelete("{id}", Name = "DeleteJobById")]
    public IActionResult DeleteById([FromRoute] int id)
    {
        _jobService.DeleteById(id);
        return NoContent();
    }



    [HttpGet]
    [Route("pokemon/{nome}")]
    public IActionResult FindPokemon(string nome)
    {
        string result = $"https://pokeapi.co/api/v2/pokemon/{nome}".GetStringAsync().GetAwaiter().GetResult();

        return Ok(result);
    }
}