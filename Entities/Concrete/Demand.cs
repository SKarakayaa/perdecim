using System.ComponentModel.DataAnnotations.Schema;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Demand : IEntity
    {
        public int Id { get; set; }
        public int DemandTypeId { get; set; }
        public string ImageName { get; set; }
        public string Name { get; set; }

        [ForeignKey(nameof(DemandTypeId))]
        public virtual DemandType DemandType { get; set; }
    }
}