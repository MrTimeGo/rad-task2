using BookAppBackend.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BookAppBackend.Controllers
{
    [Route("api")]
    [ApiController]
    public class BookController : ControllerBase
    {
        [HttpGet("books")]
        public Task<ActionResult<List<BookOverviewDto>>> GetAllBooks([FromQuery(Name = "order")] string order)
        {
            throw new NotImplementedException();
        }

        [HttpGet("recomended")]
        public Task<ActionResult<List<BookOverviewDto>>> GetTopTenHighRatedFilteredByGenre([FromQuery(Name = "genre")] string genre)
        {
            throw new NotImplementedException();
        }

        [HttpGet("books/{id}")]
        public Task<ActionResult<BookDetailedDto>> GetBookDetails([FromRoute(Name = "id")] int id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("books/{id}")]
        public Task<IActionResult> DeleteBook([FromRoute(Name = "id")] int id,
                                              [FromQuery(Name = "secret")] string secret)
        {
            throw new NotImplementedException();
        }

        [HttpPost("books/save")]
        public Task<ActionResult<int>> SaveBook([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Disallow)] BookDto book)
        {
            throw new NotImplementedException();
        }
        
        [HttpPut("books/{id}/review")]
        public Task<ActionResult<int>> SaveReview([FromRoute(Name = "id")] int id,
                                                  [FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Disallow)] ReviewDto review)
        {
            throw new NotImplementedException();
        }
        
        [HttpPut("books/{id}/rate")]
        public Task<IActionResult> RateBook([FromRoute(Name = "id")] int id,
                                            [FromBody(EmptyBodyBehavior= EmptyBodyBehavior.Disallow)] RatingDto rating)
        {
            throw new NotImplementedException();
        }
    }
}
