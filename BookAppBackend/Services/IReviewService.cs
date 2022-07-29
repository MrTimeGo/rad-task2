using BookAppBackend.Dto;

namespace BookAppBackend.Services
{
    public interface IReviewService
    {
        public Task<int> SaveReview(ReviewDto reviewDto);
    }
}
