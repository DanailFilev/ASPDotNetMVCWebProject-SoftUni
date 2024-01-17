namespace BookStore.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Review;
    /// <summary>
    /// Represents reviews for books.
    /// </summary>
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [Required]
        public int BookId { get; set; }

        public Guid? UserId { get; set; }

        [Required]
        [MaxLength(CommentMaxLength)]
        public string Comment { get; set; }

        [Required]
        [Range(RatingMinValue, RatingMaxValue)]
        public int Rating { get; set; }

        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }
    }
}
