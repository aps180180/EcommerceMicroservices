namespace Microservices.Services.ShoppingCartAPI.Models.DTO
{
    public class CartHeaderDTO
    {
        
        public int CartHeaderId { get; set; }
        public string? UserId { get; set; }
        public string? CouponCode { get; set; }        
        public Decimal Discount { get; set; }        
        public Decimal CartTotal { get; set; }
    }
}
