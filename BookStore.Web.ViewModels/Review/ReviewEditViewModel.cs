namespace BookStore.Web.ViewModels.Review
{
    using System.ComponentModel.DataAnnotations;

    public class ReviewEditViewModel
    {
        [Range(1, int.MaxValue, ErrorMessage = "ReviewId must be greater than 0.")]
        public int ReviewId { get; set; }

        [Required(ErrorMessage = "Comment is required.")]
        public string Comment { get; set; }

        [Required(ErrorMessage = "Rating is required.")]
        [Range(1, 5, ErrorMessage = "Rating must be between {1} and {2}.")]
        public int Rating { get; set; }
    }
}
