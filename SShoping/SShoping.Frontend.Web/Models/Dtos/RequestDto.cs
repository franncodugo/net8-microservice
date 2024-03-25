using static SShoping.Frontend.Web.Util.StaticDetails;

namespace SShoping.Frontend.Web.Models.Dtos;

public sealed class RequestDto
{
    public ApiType ApiType { get; set; } = ApiType.GET;
    public string Url { get; set; }
    public object Data { get; set; }
    public string AccessToken { get; set; }
}
