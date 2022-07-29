using AutoMapper;
using BookAppBackend.Data;
using BookAppBackend.Dto;
using BookAppBackend.Models;

namespace BookAppBackend.Services
{
    public class RatingService : IRatingService
    {
        private readonly BooksContext context;
        private readonly IMapper mapper;

        public RatingService(BooksContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task RateBook(int bookId, RatingDto ratingDto)
        {
            var rating = mapper.Map<Rating>(ratingDto);
            rating.BookId = bookId;
            context.Ratings.Add(rating);
            await context.SaveChangesAsync();
        }
    }
}
