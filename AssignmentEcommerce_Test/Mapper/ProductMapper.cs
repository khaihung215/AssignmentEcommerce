using AssignmentEcommerce_Backend.Models;
using AssignmentEcommerce_Shared;
using AutoMapper;

namespace AssignmentEcommerce_Test.Mapper
{
    public static class ProductMapper
    {
        public static IMapper Get()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductVm, Product>()
                .ForPath(p => p.Category.NameCategory, pm => pm.MapFrom(o => o.NameCategory))
                .ReverseMap();

                cfg.CreateMap<ProductCreateRequest, Product>().ReverseMap();
                cfg.CreateMap<ProductUpdateRequest, Product>().ReverseMap();
            });

            return config.CreateMapper();
        }
    }
}
