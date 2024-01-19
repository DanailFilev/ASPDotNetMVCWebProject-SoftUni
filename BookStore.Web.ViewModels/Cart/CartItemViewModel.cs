namespace BookStore.Web.ViewModels.Cart
{
    public class CartItemViewModel
    {
        public int CartItemId { get; set; }
        public int BookId { get; set; }
        public string Title { get; set; }
        public int Quantity { get; set; }
    }
}
