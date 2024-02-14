using Microservices.Services.ShoppingCartAPI.Models.DTO;

namespace Microservices.Services.ShoppingCartAPI.Service.IService
{
    public interface ICouponService
    {
        Task<CouponDTO> GetCoupon( string couponCode);
    }
}
