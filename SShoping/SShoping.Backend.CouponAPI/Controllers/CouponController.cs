using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SShoping.Backend.CouponAPI.Data;
using SShoping.Backend.CouponAPI.Models;
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

    [HttpPost]
    public ResponseDto CreateCoupon([FromBody] CouponDto couponDto)
    {
        try
        {
            var entity = _mapper.Map<Coupon>(couponDto);

            _context.Coupons.Add(entity);
            _context.SaveChanges();

            var dtoResult = _mapper.Map<CouponDto>(entity);
            _resposeDto.Result = dtoResult;
        }
        catch (Exception ex)
        {
            _resposeDto.IsSuccess = false;
            _resposeDto.Message = ex.Message;
        }

        return _resposeDto;
    }

    [HttpPut]
    public ResponseDto UpdateCoupon([FromBody] CouponDto couponDto)
    {
        try
        {
            var entity = _mapper.Map<Coupon>(couponDto);

            _context.Coupons.Update(entity);
            _context.SaveChanges();

            var dtoResult = _mapper.Map<CouponDto>(entity);
            _resposeDto.Result = dtoResult;
        }
        catch (Exception ex)
        {
            _resposeDto.IsSuccess = false;
            _resposeDto.Message = ex.Message;
        }

        return _resposeDto;
    }

    [HttpDelete]
    public ResponseDto DeleteCoupon(int id)
    {
        try
        {
            var entity = _context.Coupons.FirstOrDefault(c => c.CoupoinId == id);

            if (entity is null)
                throw new Exception();

            _context.Coupons.Remove(entity);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            _resposeDto.IsSuccess = false;
            _resposeDto.Message = ex.Message;
        }

        return _resposeDto;
    }
}