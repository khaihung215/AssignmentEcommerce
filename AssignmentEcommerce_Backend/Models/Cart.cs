using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentEcommerce_Backend.Models
{
    public class Cart
    {
        public string CartId { get; set; }

        public string UserId { get; set; }

        public virtual ICollection<CartDetail> CartDetails { get; set; }
    }
}
