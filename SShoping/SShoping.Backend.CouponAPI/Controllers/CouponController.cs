using Microsoft.AspNetCore.Mvc;
using SShoping.Backend.CouponAPI.Data;

namespace SShoping.Backend.CouponAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CouponController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CouponController(ApplicationDbContext context)
        => _context = context ?? throw new ArgumentNullException(nameof(context));

    [HttpGet]
    public IActionResult GetCoupon()
    {
        try
        {
            var result = _context.Coupons.ToList();
            return Ok(result);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

}