namespace Jobs.Api.Common.Dtos;
public class LinkResponse
{
    private string v;

    public string? Href { get; set; }
    public string Type { get; set; }
    public string Rel { get; set; }
    public LinkResponse(string? href, string type, string rel)
    {
        Href = href;
        Type = type;
        Rel = rel;
    }

    public LinkResponse(string v)
    {
        this.v = v;
    }
}