namespace BookStore.Services.Data.Interfaces
{
    using BookStore.Web.ViewModels.Review;

    public interface IReviewService
    {
        Task<IEnumerable<ReviewViewModel>> GetAllReviewsAsync();
        Task CreateReviewAsync(ReviewViewModel reviewViewModel);
    }
}
