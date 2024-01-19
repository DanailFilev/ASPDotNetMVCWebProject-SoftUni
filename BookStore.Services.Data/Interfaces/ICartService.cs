namespace BookStore.Services.Data.Interfaces
{
    using BookStore.Web.ViewModels.Cart;

    public interface ICartService
    {
        Task<CartViewModel> GetCartAsync(Guid userId);
        Task AddToCartAsync(Guid userId, int bookId, int quantity);
        Task RemoveFromCartAsync(Guid userId, int cartItemId);
        Task ClearCartAsync(Guid userId);
    }
}
