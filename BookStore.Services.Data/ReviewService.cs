namespace BookStore.Services.Data
{
    using BookStore.Data;
    using BookStore.Data.Models;

    public class ReviewService
    {
        private readonly BookStoreDbContext dbContext;

        public ReviewService(BookStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Review> GetReviewsByBook(int bookId)
        {
            return this.dbContext.Reviews.Where(r => r.BookId == bookId).ToList();
        }

        public void AddReview(Review review)
        {
            this.dbContext.Reviews.Add(review);
            this.dbContext.SaveChanges();
        }

        public Review GetReviewById(int reviewId)
        {
            return this.dbContext.Reviews.Find(reviewId);
        }

        public void UpdateReview(Review review)
        {
            this.dbContext.Reviews.Update(review);
            this.dbContext.SaveChanges();
        }

        public void DeleteReview(int reviewId)
        {
            var review = dbContext.Reviews.Find(reviewId);
            if (review != null)
            {
                this.dbContext.Reviews.Remove(review);
                this.dbContext.SaveChanges();
            }
        }
    }
}
