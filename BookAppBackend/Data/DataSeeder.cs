using BookAppBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace BookAppBackend.Data
{
    public static class DataSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(new List<Book>()
            {
                new Book {Id = 1, Title = "WHERE THE CRAWDADS SING", Author = "Delia Owens", Content = "In a quiet town on the North Carolina coast in 1969, a young woman who survived alone in the marsh becomes a murder suspect.", Genre = "Fantasy"},
                new Book {Id = 2, Title = "IT ENDS WITH US", Author = "Colleen Hoover", Content = "A battered wife raised in a violent home attempts to halt the cycle of abuse.", Genre = "Science Fiction"},
                new Book {Id = 3, Title = "PORTRAIT OF AN UNKNOWN WOMAN", Author = "Daniel Silva", Content = "The 22nd book in the Gabriel Allon series. Allon becomes an art forger to uncover a multibillion-dollar fraud.", Genre = "Dystopian"},
                new Book {Id = 4, Title = "VERITY", Author = "Colleen Hoover", Content = "Lowen Ashleigh is hired by the husband of an injured writer to complete her popular series and uncovers a horrifying truth.", Genre = "Adventure"},
                new Book {Id = 5, Title = "UGLY LOVE", Author = "Colleen Hoover", Content = "Tate Collins and Miles Archer, an airline pilot, think they can handle a no strings attached arrangement. But they can't.", Genre = "Romance"},
                new Book {Id = 6, Title = "PORTRAIT OF AN UNKNOWN WOMAN", Author = "Daniel Silva", Content = "The 22nd book in the Gabriel Allon series. Allon becomes an art forger to uncover a multibillion-dollar fraud.", Genre = "Detective & Mystery"},
                new Book {Id = 7, Title = "THE 6:20 MAN", Author = "David Baldacci", Content = "When his ex-girlfriend turns up dead in his office building, an entry-level investment analyst delves into the halls of economic power.", Genre = "Horror"},
                new Book {Id = 8, Title = "SHATTERED", Author = "James Patterson and James O. Born", Content = "The 14th book in the Michael Bennett series. When an F.B.I. abduction specialist disappears, Bennett goes outside his jurisdiction.", Genre = "Thriller"},
                new Book {Id = 9, Title = "THE HOTEL NANTUCKET", Author = "Elin Hilderbrand", Content = "The new general manager of a hotel far from its Gilded Age heyday deals with the complicated pasts of her guests and staff.", Genre = "LGBTQ+"},
                new Book {Id = 10, Title = "THE IT GIRL", Author = "Ruth Ware", Content = "A decade after her first year at Oxford, an expectant mother looks into the mystery of her former best friend’s death.", Genre = "Historical Fiction"}
            });

            modelBuilder.Entity<Review>().HasData(GetReviews());
            modelBuilder.Entity<Rating>().HasData(GetRatings());
        }

        private static IEnumerable<Rating> GetRatings()
        {
            for (int i = 0; i < 30; i++)
            {
                yield return new Rating
                {
                    Id = i + 1,
                    BookId = (i % 10) + 1,
                    Score = (decimal)(Random.Shared.NextDouble() * 5)
                };
            }
        }

        private static IEnumerable<Review> GetReviews()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            for (int i = 0; i < 30; i++)
            {
                int strLength = Random.Shared.Next(10);
                yield return new Review
                {
                    Id = i + 1,
                    BookId = (i % 10) + 1,
                    Message = new string(Enumerable.Repeat(chars, strLength).Select(s => s[Random.Shared.Next(s.Length)]).ToArray()),
                    Reviewer = new string(Enumerable.Repeat(chars, strLength).Select(s => s[Random.Shared.Next(s.Length)]).ToArray())
                };
            }
        }
    }
}
