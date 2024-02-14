using Microservices.Services.ShoppingCartAPI.Models.DTO;

namespace Microservices.Services.ShoppingCartAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
    }
}
