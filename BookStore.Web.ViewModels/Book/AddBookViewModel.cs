using System.ComponentModel.DataAnnotations;
using BookStore.Web.ViewModels.Genre;
using static BookStore.Common.EntityValidationConstants.Book;
using static BookStore.Common.EntityValidationConstants.Author;


namespace BookStore.Web.ViewModels.Book
{
    public class AddBookViewModel
    {
        [Required(ErrorMessage = "The Title field is required.")]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = "The Title must be between {2} and {1} characters.")]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        public string AuthorFirstName { get; set; } = null!;

        [Required]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
        public string AuthorLastName { get; set; } = null!;

        [Required]  
        public int AuthorId { get; set; }

        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string? Description { get; set; }

        [StringLength(BiographyMaxLength, MinimumLength = BiographyMinLength)]
        public string? AuthorBiography { get; set; }

        public decimal Price { get; set; }   

        [Required(AllowEmptyStrings = false)]
        public string Url { get; set; } = null!;

        [Range(1, int.MaxValue, ErrorMessage = "Please select a Genre.")]
        public int GenreId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select a Quantity.")]
        public int StockQuantity { get; set; }  
        public ICollection<GenreViewModel> Genres { get; set; } = new HashSet<GenreViewModel>();
    }
}
