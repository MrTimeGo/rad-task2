using AutoMapper;
using BookAppBackend.Dto;
using BookAppBackend.Models;

namespace BookAppBackend.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, ReviewDto>().ReverseMap();
        }
    }
}
