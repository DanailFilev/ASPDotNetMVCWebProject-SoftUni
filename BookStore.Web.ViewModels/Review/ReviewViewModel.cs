namespace BookStore.Web.ViewModels.Review
{
    using System.ComponentModel.DataAnnotations;

    public class ReviewViewModel
    {
        public int ReviewId { get; set; }

        [Required(ErrorMessage = "Comment is required.")]
        public string Comment { get; set; }

        [Required(ErrorMessage = "Rating is required.")]
        [Range(1, 5, ErrorMessage = "Rating must be between {1} and {2}.")]
        public int Rating { get; set; }
        public int BookId { get; set; }

        // Optional: If you want to display book information in the view
        [StringLength(1, MinimumLength = 100, ErrorMessage = "BookTitle must be between {2} and {1} characters.")]
        public string BookTitle { get; set; }

        // Optional: If you want to display user information in the view
        [StringLength(1, MinimumLength = 100, ErrorMessage = "UserName must be between {2} and {1} characters.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "UserId is required.")]
        public string UserId { get; set; }
    }
}
