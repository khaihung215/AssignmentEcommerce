using AutoMapper;
using AssignmentEcommerce_Backend.Models;
using AssignmentEcommerce_Shared;
namespace AssignmentEcommerce_Backend.Mappings
{
    public class ReviewMapper : Profile
    {
        public ReviewMapper()
        {
            CreateMap<ReviewVm, Review>().ReverseMap();
            CreateMap<ReviewFormRequest, Review>().ReverseMap();
        }
    }
}
