using SShoping.Frontend.Web.Models.Dtos;

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
            Url = "",
            AccessToken = "",
            Data = ""
        });

    public async Task<ResponseDto?> GetCouponAsync(int couponId)
    {
        throw new NotImplementedException();
    }
    public async Task<ResponseDto?> PostCouponAsync(CouponDto couponDto)
    {
        throw new NotImplementedException();
    }

    public async Task<ResponseDto?> PutCouponAsync(CouponDto couponDto)
    {
        throw new NotImplementedException();
    }

    public async Task<ResponseDto?> DeleteCouponAsync(int couponId)
    {
        throw new NotImplementedException();
    }
}
