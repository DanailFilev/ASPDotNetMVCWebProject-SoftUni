namespace BookStore.Services.Data
{
    using BookStore.Data;
    using BookStore.Data.Models;
    using BookStore.Services.Data.Interfaces;
    using BookStore.Web.ViewModels.Review;
    using Microsoft.EntityFrameworkCore;

    public class ReviewService : IReviewService
    {
        private readonly BookStoreDbContext dbContext;

        public ReviewService(BookStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<ReviewViewModel>> GetAllReviewsAsync()
        {
            return await this.dbContext.Reviews
                .Include(r => r.Book)  // Include Book navigation property
                .Include(r => r.User)  // Include User navigation property
                .Select(r => new ReviewViewModel
                {
                    ReviewId = r.ReviewId,
                    Comment = r.Comment,
                    Rating = r.Rating,
                    BookId = r.BookId,
                    BookTitle = r.Book.Title,         // Access the Title property of Book
                    UserName = r.User.UserName       // Access the UserName property of User
                })
                .ToListAsync();
        }

        public async Task CreateReviewAsync(ReviewViewModel reviewViewModel)
        {
            var review = new Review
            {
                Comment = reviewViewModel.Comment,
                Rating = reviewViewModel.Rating,
                BookId = reviewViewModel.BookId,
                // Optional: You might set UserId based on your authentication logic
                UserId = Guid.Parse(reviewViewModel.UserId)
            };

            this.dbContext.Reviews.Add(review);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
