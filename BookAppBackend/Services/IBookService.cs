using BookAppBackend.Dto;

namespace BookAppBackend.Services
{
    public interface IBookService
    {
        public Task<List<BookOverviewDto>> GetAllBooks(string? order);
        public Task<List<BookOverviewDto>> GetRecommendedBooks(string? genre);
        public Task<BookDetailedDto?> GetBook(int id);
        public Task<bool> DeleteBook(int id);
        public Task<int> AddBook(BookDto bookDto);
        public Task<bool> UpdateBook(BookDto bookDto);
        public Task<bool> BookExists(int id);
    }
}
