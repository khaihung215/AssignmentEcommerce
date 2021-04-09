using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentEcommerce_Backend.Models
{
    public class CartDetail
    {
        public string CartDetailId { get; set; }

        public int Quantity { get; set; }

        public string CartId { get; set; }

        public virtual Cart Cart { get; set; }

        public string ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
