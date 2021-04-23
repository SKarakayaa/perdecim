using Entities.Abstract;

namespace Entities.Concrete
{
    public class City : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}