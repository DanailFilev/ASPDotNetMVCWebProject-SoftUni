using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BookStore.Common.EntityValidationConstants.Book;

namespace BookStore.Web.ViewModels.Book
{
    public class BookViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Title field is required.")]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = "The Title field cannot exceed {1} characters.")]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(AuthorMaxLength, MinimumLength = AuthorMinLength, ErrorMessage = "The Author field is required.")]
        public string Author { get; set; } = null!;

        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = "The Description field cannot exceed {1} characters.")]
        public string Description { get; set; } = null!;

        [Range(1, int.MaxValue, ErrorMessage = "Please select a Genre.")]
        public int GenreId { get; set; }
    }
}
