namespace BookStore.Web.ViewModels.Review
{
    using System.ComponentModel.DataAnnotations;

    public class ReviewViewModel
    {
        public int ReviewId { get; set; }

        [Required]
        public string Comment { get; set; }

        [Required]
        public int Rating { get; set; }

        // Additional properties if needed

        public int BookId { get; set; }

        // Optional: If you want to display book information in the view
        public string BookTitle { get; set; }

        // Optional: If you want to display user information in the view
        public string UserName { get; set; }

        public string UserId { get; set; }  
    }
}
