using AutoMapper;
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
    private readonly IMapper _mapper;

    public CouponController(ApplicationDbContext context,
        IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _resposeDto = new ResponseDto();
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public ResponseDto GetCoupons()
    {
        try
        {
            var result = _context.Coupons.ToList();

            var resutlDto = _mapper.Map<List<CouponDto>>(result);

            _resposeDto.Result = resutlDto;
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
            
            var resutlDto = _mapper.Map<CouponDto>(result);

            _resposeDto.Result = resutlDto;
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