using SShoping.Frontend.Web.Models.Dtos;

namespace SShoping.Frontend.Web.Services.Coupon;

public interface ICouponService
{
    Task<ResponseDto?> GetAllCouponsAsync();
    Task<ResponseDto?> GetCouponAsync(int couponId);
    Task<ResponseDto?> PostCouponAsync(CouponDto couponDto);
    Task<ResponseDto?> PutCouponAsync(CouponDto couponDto);
    Task<ResponseDto?> DeleteCouponAsync(int couponId);
}