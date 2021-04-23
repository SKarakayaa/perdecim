using System.ComponentModel.DataAnnotations.Schema;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class UserAddress : IEntity
    {
        public int Id { get; set; }
        public int AddressType { get; set; }
        public int UserId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public int NeighborhoodId { get; set; }
        public string OpenAddress { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual AppUser User { get; set; }

        [ForeignKey(nameof(CityId))]
        public virtual City City { get; set; }

        [ForeignKey(nameof(DistrictId))]
        public virtual District District { get; set; }

        [ForeignKey(nameof(NeighborhoodId))]
        public virtual Neighborhood Neighborhood { get; set; }
    }
}