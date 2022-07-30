using BookAppBackend.Dto;
using BookAppBackend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BookAppBackend.Controllers
{
    [Route("api")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService bookService;
        private readonly IReviewService reviewService;
        private readonly IRatingService ratingService;
        private readonly IConfiguration configuration;

        public BookController(
            IBookService bookService,
            IReviewService reviewService,
            IRatingService ratingService,
            IConfiguration configuration)
        {
            this.bookService = bookService;
            this.reviewService = reviewService;
            this.ratingService = ratingService;
            this.configuration = configuration;
        }

        [HttpGet("books")]
        public async Task<ActionResult<List<BookOverviewDto>>> GetAllBooks([FromQuery(Name = "order")] string? order)
        {
            var books = await bookService.GetAllBooks(order);
            return Ok(books);
        }

        [HttpGet("recomended")]
        public async Task<ActionResult<List<BookOverviewDto>>> GetTopTenHighRatedFilteredByGenre([FromQuery(Name = "genre")] string? genre)
        {
            return Ok(await bookService.GetRecommendedBooks(genre));
        }

        [HttpGet("books/{id}")]
        public async Task<ActionResult<BookDetailedDto>> GetBookDetails([FromRoute(Name = "id")] int id)
        {
            var book = await bookService.GetBook(id);
            if (book is null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpDelete("books/{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute(Name = "id")] int id,
                                              [FromQuery(Name = "secret")] string secret)
        {
            var localSecret = configuration.GetValue<string>("deleteKey");
            if (secret != localSecret)
            {
                return Unauthorized();
            }
            bool result = await bookService.DeleteBook(id);
            if(result)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpPost("books/save")]
        public async Task<ActionResult<int>> SaveBook([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Disallow)] BookDto book)
        {
            if(book.Id is null || book.Id == 0)
            {
                int bookId = await bookService.AddBook(book);
                return Ok(bookId);
            }
            bool result = await bookService.UpdateBook(book);

            if (result)
            {
                return Ok(book.Id);
            }
            return BadRequest();
        }
        
        [HttpPut("books/{id}/review")]
        public async Task<ActionResult<int>> SaveReview([FromRoute(Name = "id")] int id,
                                                  [FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Disallow)] ReviewDto review)
        {
            int reviewId = await reviewService.SaveReview(id, review);
            return Ok(reviewId);
        }
        
        [HttpPut("books/{id}/rate")]
        public async Task<IActionResult> RateBook([FromRoute(Name = "id")] int id,
                                            [FromBody(EmptyBodyBehavior= EmptyBodyBehavior.Disallow)] RatingDto rating)
        {
            await ratingService.RateBook(id, rating);
            return Ok();
        }
    }
}
