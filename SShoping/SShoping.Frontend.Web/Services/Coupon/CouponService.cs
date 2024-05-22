using SShoping.Frontend.Web.Models.Dtos;
using SShoping.Frontend.Web.Util;

namespace SShoping.Frontend.Web.Services.Coupon;

public class CouponService : ICouponService
{
    private readonly IBaseService _baseService;

    public CouponService(IBaseService baseService)
         => _baseService = baseService ?? throw new ArgumentNullException(nameof(baseService));

    public async Task<ResponseDto?> GetAllCouponsAsync()
        => await _baseService.SendAsync(new()
        {
            ApiType = Util.StaticDetails.ApiType.GET,
            Url = StaticDetails.CouponAPIBaseUrl + "/api/coupon",
            AccessToken = "",
        });

    public async Task<ResponseDto?> GetCouponAsync(int couponId)
         => await _baseService.SendAsync(new()
         {
             ApiType = Util.StaticDetails.ApiType.GET,
             Url = StaticDetails.CouponAPIBaseUrl + "/api/coupon/id/" + couponId,
             AccessToken = "",
         });

    public async Task<ResponseDto?> PostCouponAsync(CouponDto couponDto)
         => await _baseService.SendAsync(new()
         {
             ApiType = Util.StaticDetails.ApiType.POST,
             Url = StaticDetails.CouponAPIBaseUrl + "/api/coupon",
             AccessToken = "",
             Data = couponDto
         });

    public async Task<ResponseDto?> PutCouponAsync(CouponDto couponDto)
        => await _baseService.SendAsync(new()
        {
            ApiType = Util.StaticDetails.ApiType.PUT,
            Url = StaticDetails.CouponAPIBaseUrl + "/api/coupon",
            AccessToken = "",
            Data = couponDto
        });

    public async Task<ResponseDto?> DeleteCouponAsync(int couponId)
         => await _baseService.SendAsync(new()
         {
             ApiType = Util.StaticDetails.ApiType.DELETE,
             Url = StaticDetails.CouponAPIBaseUrl + "/api/coupon/" + couponId,
             AccessToken = "",
         });
}
