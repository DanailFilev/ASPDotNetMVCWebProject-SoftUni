namespace BookStore.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represents a shopping cart for each user.
    /// </summary>
    public class Cart
    {

        [Key]
        public int CartId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
