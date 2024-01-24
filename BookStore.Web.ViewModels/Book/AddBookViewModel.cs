using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BookStore.Web.ViewModels.Genre;
using static BookStore.Common.EntityValidationConstants.Book;


namespace BookStore.Web.ViewModels.Book
{
    public class AddBookViewModel
    {
        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        public string AuthorFirstName { get; set; }

        [Required]
        public string AuthorLastName { get; set; }

        public int AuthorId { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string AuthorBiography { get; set; }

        [Range(typeof(decimal), "0", "2000")]
        public decimal Price { get; set; }   

        [Required(AllowEmptyStrings = false)]
        public string Url { get; set; } = null!;

        [Range(1, int.MaxValue)]
        public int GenreId { get; set; }

        public ICollection<GenreViewModel> Genres { get; set; } = new HashSet<GenreViewModel>();
    }
}
