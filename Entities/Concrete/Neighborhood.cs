using System.ComponentModel.DataAnnotations.Schema;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Neighborhood : IEntity
    {
        public int Id { get; set; }
        public int DistrictId { get; set; }
        public string Name { get; set; }

        [ForeignKey(nameof(DistrictId))]
        public virtual District District { get; set; }
    }
}