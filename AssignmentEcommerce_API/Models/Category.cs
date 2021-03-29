using System.Collections.Generic;

namespace AssignmentEcommerce_API.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string NameCategory { get; set; }

        public string Description { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}
