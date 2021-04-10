using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentEcommerce_Shared
{
    public class CartUpdateRequest
    {
        public string CartDetailId { get; set; }

        public int Quantity { get; set; }
    }
}
