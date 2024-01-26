namespace BookStore.Web.ViewModels.Genre
{
    using System.ComponentModel.DataAnnotations;
    using static BookStore.Common.EntityValidationConstants.Genre;
    public class GenreViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "Name must be between {2} and {1} characters.")]
        public string Name { get; set; } = null!;
    }
}
