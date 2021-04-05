using AutoMapper;
using AssignmentEcommerce_Backend.Models;
using AssignmentEcommerce_Shared;

namespace AssignmentEcommerce_Backend.Mappings
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<CategoryVm, Category>().ReverseMap();
            CreateMap<CategoryCreateRequest, Category>().ReverseMap();
        }
    }
}
