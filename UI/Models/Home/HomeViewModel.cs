using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace UI.Models.Home
{
    public class HomeViewModel
    {
        public IDataResult<List<Event>> Events { get; set; }
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
        public List<Color> Colors { get; set; }
        public List<Brand> Brands { get; set; }
    }
}