namespace SShoping.Frontend.Web.Models.Dtos;

public sealed class ResponseDto
{
    public object? Result { get; set; }
    public bool IsSuccess { get; set; } = true;
    public string Message { get; set; } = "";
}
