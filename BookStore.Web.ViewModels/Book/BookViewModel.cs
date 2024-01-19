using System.ComponentModel.DataAnnotations;
using static BookStore.Common.EntityValidationConstants.Book;

namespace BookStore.Web.ViewModels.Book
{
    public class BookViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(AuthorMaxLength, MinimumLength = AuthorMinLength)]
        public string Author { get; set; } = null!;

        [MinLength(5)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Range(1, int.MaxValue)]
        public int GenreId { get; set; }
    }
}
