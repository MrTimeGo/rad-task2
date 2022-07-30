using AutoMapper;
using BookAppBackend.Data;
using BookAppBackend.Dto;
using BookAppBackend.Models;

namespace BookAppBackend.Services
{
    public class ReviewService : IReviewService
    {
        private readonly BooksContext context;
        private readonly IMapper mapper;

        public ReviewService(BooksContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<int> SaveReview(int bookId, ReviewDto reviewDto)
        {
            var review = mapper.Map<Review>(reviewDto);
            review.BookId = bookId;
            var newReviewId = (await context.Reviews.AddAsync(review)).Entity.Id;
            await context.SaveChangesAsync();
            return newReviewId;
        }
    }
}
