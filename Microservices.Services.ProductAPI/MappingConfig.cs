using AutoMapper;
using Microservices.Services.ProductAPI.Models;
using Microservices.Services.ProductAPI.Models.DTO;

namespace Microservices.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps() 
        {
            var mappingConfig = new MapperConfiguration( config=>
            {
                config.CreateMap<ProductDTO, Product>().ReverseMap();
                

            }); 
            return mappingConfig;   
        }
    }
}
