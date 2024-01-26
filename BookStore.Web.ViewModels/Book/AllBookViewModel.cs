namespace BookStore.Web.ViewModels.Book
{
    using System.ComponentModel.DataAnnotations;
    using static BookStore.Common.EntityValidationConstants.Book;

    public class AllBookViewModel
    {
        public int BookId { get; set; }

        [Required(ErrorMessage = "The Title field is required.")]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = "The Title must be between {2} and {1} characters.")]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(AuthorMaxLength, MinimumLength = AuthorMinLength, ErrorMessage = "The Author field is required.")]
        public string Author { get; set; } = null!;

        [Required(AllowEmptyStrings = false)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = "The Description field cannot exceed {1} characters.")]
        public string ShortDescription { get; set; } = null!;
    }
}
