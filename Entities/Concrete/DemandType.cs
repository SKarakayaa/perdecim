using Entities.Abstract;

namespace Entities.Concrete
{
    public class DemandType:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}