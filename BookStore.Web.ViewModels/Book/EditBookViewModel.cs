namespace BookStore.Web.ViewModels.Book
{
    using System.ComponentModel.DataAnnotations;
    using static BookStore.Common.EntityValidationConstants.Book;
    using static BookStore.Common.EntityValidationConstants.Author;
    using BookStore.Web.ViewModels.Genre;

    public class EditBookViewModel
    {
        public int BookId { get; set; } 

        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = "The Title must be between {2} and {1} characters.")]
        public string Title { get; set; }

        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        public string AuthorFirstName { get; set; }

        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
        public string AuthorLastName { get; set; }

        public int AuthorId { get; set; }

        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; }

        [StringLength(BiographyMaxLength, MinimumLength = BiographyMinLength)]
        public string AuthorBiography { get; set; }

        public decimal Price { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Url { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select a Genre.")]
        public int GenreId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select a Quantity.")]
        public int StockQuantity { get; set; }

        public ICollection<GenreViewModel> Genres { get; set; } = new HashSet<GenreViewModel>();
    }
}
