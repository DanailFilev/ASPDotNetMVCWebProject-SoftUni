namespace BookStore.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Genre;
    /// <summary>
    /// Represents different genres for books.
    /// </summary>
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;
        public virtual ICollection<Book> Books { get; set; }
    }
}
