using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SShoping.Backend.CouponAPI.Data;
using SShoping.Backend.CouponAPI.Models.Dtos;

namespace SShoping.Backend.CouponAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CouponController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private ResponseDto _resposeDto;

    public CouponController(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _resposeDto = new ResponseDto();
    }

    [HttpGet]
    public ResponseDto GetCoupons()
    {
        try
        {
            var result = _context.Coupons.ToList();

            _resposeDto.Result = result;
        }
        catch (Exception ex)
        {
            _resposeDto.IsSuccess = false;
            _resposeDto.Message = ex.Message;
        }

        return _resposeDto;
    }
    
    [HttpGet]
    [Route("id:int")]
    public ResponseDto GetCoupon(int id)
    {
        try
        {
            var result = _context.Coupons
                .FirstOrDefault(c => c.CoupoinId == id);

            _resposeDto.Result = result;
        }
        catch (Exception ex)
        {
            _resposeDto.IsSuccess = false;
            _resposeDto.Message = ex.Message;
        }

        return _resposeDto;
    }

    // [HttpPost]
    // public IActionResult CreateCoupon(CouponDto couponDto)
    // {
    //     try
    //     {
    //         return Ok();
    //     }
    //     catch (Exception ex)
    //     {
    //         throw;
    //     }
    // }

}