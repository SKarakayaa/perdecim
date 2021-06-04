using System;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Event : IEntity
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int EventTypeId { get; set; }
        public int? DiscountRate { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal? MinPrice { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }

        [ForeignKey(nameof(EventTypeId))]
        public virtual EventType EventType { get; set; }
    }
}