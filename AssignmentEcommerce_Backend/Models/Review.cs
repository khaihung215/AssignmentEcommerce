using System;

namespace AssignmentEcommerce_Backend.Models
{
    public class Review
    {
        public string ReviewId { get; set; }

        public string Content { get; set; }

        public int Rating { get; set; }

        public string ProductId { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public DateTime DateReview { get; set; }

        public virtual Product Product { get; set; }
    }
}
