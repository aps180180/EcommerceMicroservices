using AutoMapper;
using Microservices.Services.CupomAPI.Models;
using Microservices.Services.CupomAPI.Models.DTO;

namespace Microservices.Services.CupomAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps() 
        {
            var mappingConfig = new MapperConfiguration( config=>
            {
                config.CreateMap<CouponDTO, Coupon>();
                config.CreateMap<Coupon, CouponDTO>();

            }); 
            return mappingConfig;   
        }
    }
}
