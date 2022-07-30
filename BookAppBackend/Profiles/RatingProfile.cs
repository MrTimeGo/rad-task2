using AutoMapper;
using BookAppBackend.Dto;
using BookAppBackend.Models;

namespace BookAppBackend.Profiles
{
    public class RatingProfile : Profile
    {
        public RatingProfile()
        {
            CreateMap<RatingDto, Rating>();
        }
    }
}
