using System;

namespace ViewModels
{
    public class ProductFormVm
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Images { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int CategoryId { get; set; }
    }
}
