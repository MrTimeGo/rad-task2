using BookAppBackend.Dto;

namespace BookAppBackend.Services
{
    public class BookService : IBookService
    {
        public Task<int> AddBook(BookDto bookDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<BookOverviewDto>> GetAllBooks(string? order)
        {
            throw new NotImplementedException();
        }

        public Task<Task<BookDetailedDto>> GetBook(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<BookOverviewDto>> GetRecommendedBooks(string? genre)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateBook(BookDto bookDto)
        {
            throw new NotImplementedException();
        }
    }
}
