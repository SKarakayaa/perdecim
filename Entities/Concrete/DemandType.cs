using System.Collections.Generic;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class DemandType : IEntity
    {
        public DemandType()
        {
            this.Demands = new List<Demand>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Demand> Demands { get; set; }
    }
}