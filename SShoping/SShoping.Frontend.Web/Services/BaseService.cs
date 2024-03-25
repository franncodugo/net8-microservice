using Newtonsoft.Json;
using SShoping.Frontend.Web.Models.Dtos;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using static SShoping.Frontend.Web.Util.StaticDetails;

namespace SShoping.Frontend.Web.Services;

public sealed class BaseService : IBaseService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public BaseService(IHttpClientFactory httpClientFactory)
        => _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));

    public async Task<ResponseDto?> SendAsync(RequestDto requestDto)
    {
        try
        {
            string appJson = "application/json";
            HttpClient client = _httpClientFactory.CreateClient("SShopingAPI");
            HttpRequestMessage message = new();

            message.Headers.Add("Accept", appJson);

            // TODO: Add token 

            message.RequestUri = new Uri(requestDto.Url);

            if (requestDto.Data is not null)
            {
                message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, appJson);
            }

            switch (requestDto.ApiType)
            {
                case ApiType.POST:
                    message.Method = HttpMethod.Post;
                    break;
                case ApiType.PUT:
                    message.Method = HttpMethod.Put;
                    break;
                case ApiType.DELETE:
                    message.Method = HttpMethod.Delete;
                    break;
                default:
                    message.Method = HttpMethod.Get;
                    break;
            }

            var apiResponse = await client.SendAsync(message);

            switch (apiResponse.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    return new() { IsSuccess = false, Message = "Not Found" };
                case HttpStatusCode.Forbidden:
                    return new() { IsSuccess = false, Message = "Forbidden" };
                case HttpStatusCode.BadRequest:
                    return new() { IsSuccess = false, Message = "Bad Request" };
                case HttpStatusCode.Unauthorized:
                    return new() { IsSuccess = false, Message = "Unauthorized" };
                case HttpStatusCode.OK:
                    var apiContent = await apiResponse.Content.ReadAsStringAsync();
                    var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
                    return apiResponseDto;
                default:
                    return new() { IsSuccess = false, Message = "Internal Server Error" };
            }
        }
        catch (Exception ex)
        {
            var dto = new ResponseDto()
            {
                Message = ex.Message,
                IsSuccess = false
            };
            return dto;
        }
    }
}
