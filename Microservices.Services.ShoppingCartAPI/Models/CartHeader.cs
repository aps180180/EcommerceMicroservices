using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Microservices.Services.ShoppingCartAPI.Models
{
    public class CartHeader
    {
        [Key]
        public int CartHeaderId { get; set; }
        public string? UserId { get; set; }
        public string? CouponCode { get; set; }
        [NotMapped]
        public Decimal Discount { get; set; }
        [NotMapped]
        public Decimal CartTotal { get; set; }
        public IEnumerable<CartDetails>? CartDetails { get; set; }


    }
}
