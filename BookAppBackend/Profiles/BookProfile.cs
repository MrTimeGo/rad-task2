using AutoMapper;
using BookAppBackend.Dto;
using BookAppBackend.Models;

namespace BookAppBackend.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookDto, Book>();

            CreateMap<Book, BookOverviewDto>()
                .ForMember(dest => dest.ReviewsNumber,
                    option => option.MapFrom(src => src.Reviews!.Count()))
                .ForMember(dest => dest.Rating,
                    option => option.MapFrom(src => src.Ratings!.Any() ? src.Ratings!.Average(r => r.Score) : 0));

            CreateMap<Book, BookDetailedDto>()
                .ForMember(dest => dest.Rating,
                    option => option.MapFrom(src => src.Ratings!.Any() ? src.Ratings!.Average(r => r.Score) : 0));
        }
    }
}
