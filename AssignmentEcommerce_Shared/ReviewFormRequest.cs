using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentEcommerce_Shared
{
    public class ReviewFormRequest
    {
        public string Content { get; set; }

        public int Rating { get; set; }

        public string ProductId { get; set; }

        public string UserName { get; set; }
    }
}
