namespace BookStore.Data.Models
{
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Common.EntityValidationConstants.Book;
    /// <summary>
    /// Represents individual books in the bookstore.
    /// </summary>
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [ForeignKey(nameof(AuthorId))]  
        public Author Author { get; set; } = null!;

        [Required]
        public int AuthorId { get; set; }

        [ForeignKey(nameof(GenreId))]
        public Genre Genre { get; set; } = null!;

        [Required]
        public int GenreId { get; set; }

        [Column(TypeName = PriceType)]
        public decimal Price { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Range(StockQuantityMinValue, int.MaxValue)]
        public int StockQuantity { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}