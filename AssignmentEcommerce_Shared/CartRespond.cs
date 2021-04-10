using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentEcommerce_Shared
{
    public class CartRespond
    {
        public string CartDetailId { get; set; }

        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string Image { get; set; }
    }
}
