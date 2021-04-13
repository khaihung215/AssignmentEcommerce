using AssignmentEcommerce_Backend.Models;
using AssignmentEcommerce_Shared;
using AutoMapper;

namespace AssignmentEcommerce_Test.Mapper
{
    public static class CartMapper
    {
        public static IMapper Get()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CartRespond, CartDetail>()
                    .ForPath(cd => cd.Product.Name, cr => cr.MapFrom(c => c.ProductName))
                    .ForPath(cd => cd.Product.Price, cr => cr.MapFrom(c => c.Price))
                    .ForPath(cd => cd.Product.Images, cr => cr.MapFrom(c => c.Image))
                    .ReverseMap();
            });

            return config.CreateMapper();
        }
    }
}
