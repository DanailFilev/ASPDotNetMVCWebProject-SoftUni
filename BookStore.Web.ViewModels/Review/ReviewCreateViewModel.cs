namespace BookStore.Web.ViewModels.Review
{
    using System.ComponentModel.DataAnnotations;
    
    public class ReviewCreateViewModel
    {
        public int BookId { get; set; }

        [Required]
        public string Comment { get; set; }

        [Required]
        public int Rating { get; set; }
    }
}
