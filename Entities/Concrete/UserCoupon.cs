using System.ComponentModel.DataAnnotations.Schema;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class UserCoupon : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal MinPriceForApply { get; set; }
        public decimal DiscountPrice { get; set; }
        public string Coupon { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual AppUser User { get; set; }
    }
}