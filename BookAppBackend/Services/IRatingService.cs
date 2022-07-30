using BookAppBackend.Dto;

namespace BookAppBackend.Services
{
    public interface IRatingService
    {
        public Task RateBook(int bookId, RatingDto ratingDto);
    }
}
