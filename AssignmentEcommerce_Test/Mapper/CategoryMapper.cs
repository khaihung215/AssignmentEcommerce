using AssignmentEcommerce_Backend.Models;
using AssignmentEcommerce_Shared;
using AutoMapper;

namespace AssignmentEcommerce_Test.Mapper
{
    public static class CategoryMapper
    {
        public static IMapper Get()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryVm, Category>().ReverseMap();
                cfg.CreateMap<CategoryCreateRequest, Category>().ReverseMap();
            });

            return config.CreateMapper();
        }
    }
}
