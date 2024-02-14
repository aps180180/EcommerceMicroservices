using Microservices.Web.Models;
using Microservices.Web.Service.IService;
using Microservices.Web.Utils;

namespace Microservices.Web.Service
{
    public class ProductService : IProductService
    {
        private readonly IBaseService _baseService;
        public ProductService( IBaseService baseService)
        {
                _baseService = baseService;
        }

        public async Task<ResponseDTO?> CreateProductAsync(ProductDTO productDTO)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApyType.POST,
                Data = productDTO,
                Url = $"{SD.ProductAPIBase}/api/product"

            });
        }

        public async Task<ResponseDTO?> UpdateProductAsync(ProductDTO productDTO)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApyType.PUT,
                Data = productDTO,
                Url = $"{SD.ProductAPIBase}/api/product"

            });
        }
        public async Task<ResponseDTO?> DeleteProductAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApyType.DELETE,
                Url = $"{SD.ProductAPIBase}/api/product/{id}"

            });
        }

        public async Task<ResponseDTO?> GetAllProductsAsync()
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType =SD.ApyType.GET,
                Url = $"{SD.ProductAPIBase}/api/product"            

            });
        }

        

        public async Task<ResponseDTO?> GetProductByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApyType.GET,
                Url = $"{SD.ProductAPIBase}/api/product/{id}"

            });
        }

        
    }
}
