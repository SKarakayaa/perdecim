
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Category:IEntity
    {
        public Category()
        {
            this.ChildCategories = new List<Category>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? ParentId { get; set; }

        [ForeignKey(nameof(ParentId))]
        public virtual Category ParentCategory { get; set; }

        public List<Category> ChildCategories { get; set; }
    }
}