namespace BookStore.Services.Data
{
    using BookStore.Data;
    using BookStore.Data.Models;
    using BookStore.Services.Data.Interfaces;
    using BookStore.Web.ViewModels.Cart;
    using Microsoft.EntityFrameworkCore;

    public class CartService : ICartService
    {
        private readonly BookStoreDbContext dbContext;

        public CartService(BookStoreDbContext dbContext)
        {
            this.dbContext = dbContext; 
        }

        public async Task<CartViewModel> GetCartAsync(Guid userId)
        {
            var cart = await this.dbContext.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Book)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
            {
                // Create a new cart for the user if it doesn't exist
                cart = new Cart { UserId = userId };
                this.dbContext.Carts.Add(cart);
                await this.dbContext.SaveChangesAsync();
            }

            // Map the Cart entity to CartViewModel
            var cartViewModel = new CartViewModel
            {
                CartId = cart.CartId,
                UserId = cart.UserId,
                CartItems = cart.CartItems.Select(ci => new CartItemViewModel
                {
                    CartItemId = ci.CartItemId,
                    BookId = ci.BookId,
                    Title = ci.Book.Title,
                    Quantity = ci.Quantity,
                    // Add other book properties as needed
                }).ToList()
            };

            return cartViewModel;
        }

        public async Task AddToCartAsync(Guid userId, int bookId, int quantity)
        {
            // Get the user's cart
            var cart = await this.dbContext.Carts
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
            {
                // Create a new cart for the user if it doesn't exist
                cart = new Cart { UserId = userId };
                this.dbContext.Carts.Add(cart);
            }

            // Check if the book is already in the cart
            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.BookId == bookId);

            if (cartItem != null)
            {
                // Update quantity if the book is already in the cart
                cartItem.Quantity += quantity;
            }
            else
            {
                // Add a new cart item if the book is not in the cart
                cart.CartItems.Add(new CartItem { BookId = bookId, Quantity = quantity });
            }

            await this.dbContext.SaveChangesAsync();
        }

        public async Task RemoveFromCartAsync(Guid userId, int cartItemId)
        {
            var cart = await this.dbContext.Carts
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart != null)
            {
                var cartItem = cart.CartItems.FirstOrDefault(ci => ci.CartItemId == cartItemId);

                if (cartItem != null)
                {
                    cart.CartItems.Remove(cartItem);
                    await this.dbContext.SaveChangesAsync();
                }
            }
        }

        public async Task ClearCartAsync(Guid userId)
        {
            var cart = await this.dbContext.Carts
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart != null)
            {
                cart.CartItems.Clear();
                await this.dbContext.SaveChangesAsync();
            }
        }
    }
}
