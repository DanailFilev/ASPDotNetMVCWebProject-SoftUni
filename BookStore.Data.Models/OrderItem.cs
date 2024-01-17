namespace BookStore.Data.Models
{
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.OrderItem;
    /// <summary>
    /// Represents individual items within an order.
    /// </summary>
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        [Range(QuantityMinValue, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = UnitPriceType)]
        public decimal UnitPrice { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }

        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; }
    }
}
