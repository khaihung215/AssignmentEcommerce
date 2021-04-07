using AutoMapper;
using AssignmentEcommerce_Backend.Models;
using AssignmentEcommerce_Shared;

namespace AssignmentEcommerce_Backend.Mappings
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<ProductVm, Product>()
                .ForPath(p => p.Category.NameCategory, pm => pm.MapFrom(o => o.NameCategory))
                .ReverseMap();

            CreateMap<ProductCreateRequest, Product>().ReverseMap();
            CreateMap<ProductUpdateRequest, Product>().ReverseMap();
        }
    }
}
