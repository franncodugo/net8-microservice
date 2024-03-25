using SShoping.Frontend.Web.Models.Dtos;

namespace SShoping.Frontend.Web.Services;

public interface IBaseService
{
    Task<ResponseDto?> SendAsync(RequestDto requestDto);
}
