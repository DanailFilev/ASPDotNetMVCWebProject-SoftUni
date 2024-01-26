namespace BookStore.Web.ViewModels.Review
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class ReviewCreateViewModel
    {
        [Required(ErrorMessage = "Comment is required.")]
        public string Comment { get; set; }

        [Required(ErrorMessage = "Rating is required.")]
        [Range(1, 5, ErrorMessage = "Rating must be between {1} and {2}.")]
        public int Rating { get; set; }

        [Required(ErrorMessage = "Please select a Book.")]
        public int BookId { get; set; }

        // Property to hold the dropdown list
        public List<SelectListItem> Books { get; set; }
    }
}
