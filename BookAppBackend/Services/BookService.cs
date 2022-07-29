using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookAppBackend.Data;
using BookAppBackend.Dto;
using BookAppBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace BookAppBackend.Services
{
    public class BookService : IBookService
    {
        private readonly BooksContext context;
        private readonly IMapper mapper;

        public BookService(BooksContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<int> AddBook(BookDto bookDto)
        {
            var book = mapper.Map<Book>(bookDto);
            var bookId = (await context.Books.AddAsync(book)).Entity.Id;
            await context.SaveChangesAsync();
            return bookId;
        }

        public async Task<bool> BookExists(int id)
        {
            return await context.Books.AnyAsync(b => b.Id == id);
        }

        public async Task<bool> DeleteBook(int id)
        {
            var bookToRemove = await context.Books.FirstOrDefaultAsync(b => b.Id == id);
            if (bookToRemove is null)
            {
                return false;
            }

            context.Books.Remove(bookToRemove);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<BookOverviewDto>> GetAllBooks(string? order)
        {
            var books = context.Books.ProjectTo<BookOverviewDto>(mapper.ConfigurationProvider);
            if (order == "title")
            {
                books.OrderBy(b => b.Title);
            }
            else if (order == "author")
            {
                books.OrderBy(b => b.Author);
            }
            return await books.ToListAsync();
        }

        public async Task<BookDetailedDto?> GetBook(int id)
        {
            return await context.Books.Include(b => b.Reviews)
                .ProjectTo<BookDetailedDto>(mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(b => b.Id == id);
        }

        public async Task<List<BookOverviewDto>> GetRecommendedBooks(string? genre)
        {
            const int minNumberOFReviews = 10;
            const int limit = 10;
            return await context.Books.ProjectTo<BookOverviewDto>(mapper.ConfigurationProvider)
                .Where(b => b.ReviewsNumber > minNumberOFReviews)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<bool> UpdateBook(BookDto bookDto)
        {
            var oldBook = await context.Books.FirstOrDefaultAsync(b => b.Id == bookDto.Id);
            if (oldBook is null)
            {
                return false;
            }
            var updatedBook = mapper.Map(bookDto, oldBook);
            context.Update(updatedBook);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
