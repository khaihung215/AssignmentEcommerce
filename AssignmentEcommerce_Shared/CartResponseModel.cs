using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentEcommerce_Shared
{
    public class CartResponseModel<TModel>
    {
        public decimal TotalPrice { get; set; }

        public int TotalItems { get; set; }

        public IEnumerable<TModel> Items { get; set; }
    }
}
