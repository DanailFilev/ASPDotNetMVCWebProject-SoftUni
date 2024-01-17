namespace BookStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Common.EntityValidationConstants.Order;
    /// <summary>
    /// Represents an order made by a user.
    /// </summary>
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Column(TypeName = TotalAmountType)]
        [Range(TotalAmountMinValue, (double)decimal.MaxValue)]
        public decimal TotalAmount { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
