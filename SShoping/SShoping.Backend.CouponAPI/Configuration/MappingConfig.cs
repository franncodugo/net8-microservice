using AutoMapper;
using SShoping.Backend.CouponAPI.Models;
using SShoping.Backend.CouponAPI.Models.Dtos;

namespace SShoping.Backend.CouponAPI.Configuration;

public sealed class MappingConfig
{
    public static MapperConfiguration RegisterMap()
    {
        var mappingConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<CouponDto, Coupon>();
            config.CreateMap<Coupon, CouponDto>();
        });

        return mappingConfig;
    }
}