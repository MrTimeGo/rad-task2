using FluentValidation;

namespace BookAppBackend.Dto
{
    public class ReviewDto
    {
        public int? Id { get; set; }
        public string Message { get; set; } = string.Empty;
        public string Reviewer { get; set; } = string.Empty;
    }

    public class ReviewDtoValidator : AbstractValidator<ReviewDto>
    {
        public ReviewDtoValidator()
        {
            RuleFor(r => r.Message)
                .NotNull()
                .NotEmpty();
            RuleFor(r => r.Reviewer)
                .NotNull()
                .NotEmpty();
        }
    }
}
