namespace BookStore.Web.ViewModels.Cart
{
    public class CartViewModel
    {
        public int CartId { get; set; }
        public Guid UserId { get; set; }
        public List<CartItemViewModel> CartItems { get; set; }
    }
}
