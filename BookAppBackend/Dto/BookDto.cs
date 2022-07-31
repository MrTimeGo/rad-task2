using FluentValidation;

namespace BookAppBackend.Dto
{
    public class BookDto
    {
        public int? Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Cover { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
    }

    public class BookDtoValidator : AbstractValidator<BookDto>
    {
        public BookDtoValidator()
        {
            RuleFor(b => b.Title)
                .NotNull()
                .NotEmpty();
            RuleFor(b => b.Content)
                .NotNull()
                .NotEmpty();
            RuleFor(b => b.Author)
                .NotNull()
                .NotEmpty();
            RuleFor(b => b.Genre)
                .NotNull()
                .NotEmpty();
        }
    }
}
