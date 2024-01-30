namespace BookStore.Services.Data.Interfaces
{
    using BookStore.Data.Models;
    using BookStore.Web.ViewModels.Cart;

    public interface ICartService
    {
        Task<CartViewModel> GetCartAsync(Guid userId);
        //int GetItemCount();
        Task AddToCartAsync(Guid userId, int bookId, int quantity);
        Task RemoveFromCartAsync(Guid userId, int cartItemId);
        Task ClearCartAsync(Guid userId);

        public int GetItemsCount(Guid userId);
		Task<CartItem> GetCartItemAsync(Guid userId, int cartItemId);
        Task UpdateQuantityAsync(Guid userId, int cartItemId, int newQuantity);
    }
}
