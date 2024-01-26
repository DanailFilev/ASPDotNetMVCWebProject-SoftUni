namespace BookStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Author;
    /// <summary>
    /// Represents authors of books.
    /// </summary>
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; }

        [MaxLength(BiographyMaxLength)]
        [DataType(DataType.MultilineText)]
        public string? Biography { get; set; }

        public virtual ICollection<Book>? Books { get; set; }
    }
}
