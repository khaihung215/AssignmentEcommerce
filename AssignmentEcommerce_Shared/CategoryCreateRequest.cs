using Microsoft.AspNetCore.Http;

namespace AssignmentEcommerce_Shared
{
    public class CategoryCreateRequest
    {
        public string NameCategory { get; set; }

        public string Description { get; set; }

        public IFormFile ThumbnailImages { get; set; }
    }
}