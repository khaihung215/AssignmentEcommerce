using AutoMapper;
using AssignmentEcommerce_Backend.Models;
using AssignmentEcommerce_Shared;

namespace AssignmentEcommerce_Backend.Mappings
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<ProductVm, Product>().ReverseMap();
            CreateMap<ProductCreateRequest, Product>().ReverseMap();
        }
    }
}
