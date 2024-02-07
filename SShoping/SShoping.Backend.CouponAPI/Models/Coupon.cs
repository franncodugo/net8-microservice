using System.ComponentModel.DataAnnotations;

namespace SShoping.Backend.CouponAPI.Models;

public sealed class Coupon
{
    [Key]
    public int CoupoinId { get; set; }
    [Required]
    public string CouponCode { get; set; }
    [Required]
    public double DiscountAmount { get; set; }
    public int MinAmount { get; set; }
}