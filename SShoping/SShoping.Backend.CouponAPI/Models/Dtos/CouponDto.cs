namespace SShoping.Backend.CouponAPI.Models.Dtos;

public sealed class CouponDto
{
    public int CoupoinId { get; set; }
    public string CouponCode { get; set; }
    public double DiscountAmount { get; set; }
    public int MinAmount { get; set; }
}