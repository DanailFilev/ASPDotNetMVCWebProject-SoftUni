namespace BookStore.Services.Data.Interfaces
{
    using BookStore.Data.Models;

    public interface IReviewService
    {
        IEnumerable<Review> GetReviewsByBook(int bookId);
        void AddReview(Review review);
        Review GetReviewById(int reviewId);
        void UpdateReview(Review review);
        void DeleteReview(int reviewId);
    }
}
