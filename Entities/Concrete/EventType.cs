using Entities.Abstract;

namespace Entities.Concrete
{
    public class EventType : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}