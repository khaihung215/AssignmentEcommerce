using AutoMapper;
using AssignmentEcommerce_Backend.Models;
using AssignmentEcommerce_Shared;

namespace AssignmentEcommerce_Backend.Mappings
{
    public class CartMapper : Profile
    {
        public CartMapper()
        {
            CreateMap<CartRespond, CartDetail>()
                .ForPath(cd => cd.Product.Name, cr => cr.MapFrom(c => c.ProductName))
                .ForPath(cd => cd.Product.Price, cr => cr.MapFrom(c => c.Price))
                .ForPath(cd => cd.Product.Images, cr => cr.MapFrom(c => c.Image))
                .ReverseMap();
        }
       
    }
}
