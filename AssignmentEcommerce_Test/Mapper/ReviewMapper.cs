using AssignmentEcommerce_Backend.Models;
using AssignmentEcommerce_Shared;
using AutoMapper;

namespace AssignmentEcommerce_Test.Mapper
{
    public static class ReviewMapper
    {
        public static IMapper Get()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ReviewVm, Review>().ReverseMap();
                cfg.CreateMap<ReviewFormRequest, Review>().ReverseMap();
            });

            return config.CreateMapper();
        }
    }
}
