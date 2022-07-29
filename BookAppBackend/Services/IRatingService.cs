using BookAppBackend.Dto;

namespace BookAppBackend.Services
{
    public interface IRatingService
    {
        public Task<bool> RateBook(RatingDto ratingDto);
    }
}
