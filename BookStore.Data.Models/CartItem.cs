namespace BookStore.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.CartItem;
    /// <summary>
    /// Represents individual items within a user's shopping cart.
    /// </summary>
    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; }

        [Required]
        public int CartId { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        [Range(QuantityMinValue, int.MaxValue)]
        public int Quantity { get; set; }

        [ForeignKey(nameof(CartId))]
        public Cart Cart { get; set; }

        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; }
    }
}
