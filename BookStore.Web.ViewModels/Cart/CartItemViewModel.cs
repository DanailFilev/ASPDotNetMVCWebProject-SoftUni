namespace BookStore.Web.ViewModels.Cart
{
    using System.ComponentModel.DataAnnotations;
    using static BookStore.Common.EntityValidationConstants.CartItem;

    public class CartItemViewModel
    {
        public int CartItemId { get; set; }

        public int BookId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = "Title must be between {2} and {1} characters.")]
        public string Title { get; set; } = null!;

        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public int Quantity { get; set; }
    }
}
