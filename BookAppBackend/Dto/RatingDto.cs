using FluentValidation;

namespace BookAppBackend.Dto
{
    public class RatingDto
    {
        public int? Id { get; set; }
        public decimal Score { get; set; }
    }

    public class RatingDtoValidator : AbstractValidator<RatingDto>
    {
        public RatingDtoValidator()
        {
            RuleFor(r => r.Score)
                .InclusiveBetween(1, 5);
        }
    }
}
