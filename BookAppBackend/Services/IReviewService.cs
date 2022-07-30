using BookAppBackend.Dto;

namespace BookAppBackend.Services
{
    public interface IReviewService
    {
        public Task<int> SaveReview(int bookId, ReviewDto reviewDto);
    }
}
