namespace BookStore.Web.Controllers
{
    using BookStore.Services.Data.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    public class CartController : BaseController
    {
        private readonly ICartService cartService;
        private readonly IBookService bookService;

        public CartController(ICartService cartService, IBookService bookService)
        {
            this.cartService = cartService;
            this.bookService = bookService;
        }

        // GET: Cart
        public async Task<IActionResult> Index()
        {
            var userId = GetCurrentUserId();
            var cartViewModel = await this.cartService.GetCartAsync(userId);

            int itemCount = cartService.GetItemCount();

            // Pass the count to the view
            ViewBag.CartItemCount = itemCount;

            // Assuming CartViewModel has a property named CartItems
            var cartItemViewModels = cartViewModel.CartItems;

            return View(cartItemViewModels);
        }

        // POST: Cart/UpdateQuantity
        [HttpPost]
        public async Task<IActionResult> UpdateQuantity(int cartItemId, int quantity)
        {
            var userId = GetCurrentUserId();

            // Ensure the cartItemId is valid before updating the quantity
            var cartItem = await cartService.GetCartItemAsync(userId, cartItemId);
            if (cartItem == null)
            {
                return NotFound(); // Handle invalid cartItemId
            }

            await cartService.UpdateQuantityAsync(userId, cartItemId, quantity);

            return Ok(); // Return success status
        }


        // POST: Cart/AddToCart
        [HttpPost]
        public async Task<IActionResult> AddToCart(int bookId, int quantity)
        {
            var userId = GetCurrentUserId();
           
            // Ensure the bookId is valid before adding to the cart
            var book = await bookService.GetBookByIdAsync(bookId);
            if (book == null)
            {
                return NotFound(); // Handle invalid bookId
            }

            await cartService.AddToCartAsync(userId, bookId, quantity);

            return RedirectToAction("Index");

        }

        // POST: Cart/RemoveFromCart
        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int cartItemId)
        {
            var userId = GetCurrentUserId();
            await cartService.RemoveFromCartAsync(userId, cartItemId);

            return RedirectToAction("Index");
        }

        // POST: Cart/ClearCart
        [HttpPost]
        public async Task<IActionResult> ClearCart()
        {
            var userId = GetCurrentUserId();
            await cartService.ClearCartAsync(userId);

            return RedirectToAction("Index");
        }
    }
}
